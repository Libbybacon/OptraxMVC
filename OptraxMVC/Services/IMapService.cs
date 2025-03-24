using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Valid;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Map;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IMapService
    {
        Task<ResponseVM> GetObjectsAsync(string objType);
        Task<object?> GetObjectAsync(int id, string objType);
        Task<ResponseVM> CreateObjectAsync(MapObject obj);
        Task<ResponseVM> EditObjectAsync(MapObject obj);
        Task<ResponseVM> DeleteObjectAsync(int id, string objType);
    }

    public class MapService(OptraxContext context) : IMapService
    {
        private readonly OptraxContext db = context;

        public async Task<ResponseVM> GetObjectsAsync(string objType)
        {
            try
            {
                var features = objType switch
                {
                    "Point" => (await db.MapPoints.Where(p => p.Active).Include(p => p.Icon).ToListAsync()).Select(p => p.ToGeoJSON()).ToList(),
                    "Line" => [.. (await db.MapLines.Where(p => p.Active).ToListAsync()).Select(p => p.ToGeoJSON())],
                    "Circle" => [.. (await db.MapCircles.Where(p => p.Active).ToListAsync()).Select(p => p.ToGeoJSON())],
                    "Polygon" => [.. (await db.MapPolygons.Where(p => p.Active).ToListAsync()).Select(p => p.ToGeoJSON())],
                    _ => throw new NotImplementedException()
                };
                var geoJson = new
                {
                    type = "FeatureCollection",
                    features
                };

                return new ResponseVM() { Success = true, Data = geoJson };
            }
            catch (Exception ex)
            {
                return new ResponseVM() { Msg = "Error getting map objects: " + ex.Message };
            }
        }

        public async Task<object?> GetObjectAsync(int id, string objType)
        {
            MapObject? dbObj = await db.MapObjects.FindAsync(id);

            if (dbObj == null)
            {
                return new ResponseVM() { Msg = "Could not find map object" };
            }
            if (dbObj is MapShape shape)
            {
                shape.Color = shape.ColorBytes.ToString();
                if (shape is not MapLine)
                {
                    shape.FillColor = shape.FillColorBytes.ToString();
                }
            }

            return dbObj switch
            {
                MapPoint => dbObj as MapPoint,
                MapLine => dbObj as MapLine,
                MapCircle => dbObj as MapCircle,
                MapPolygon => dbObj as MapPolygon,
                _ => throw new NotImplementedException()
            };
        }

        public async Task<ResponseVM> CreateObjectAsync(MapObject obj)
        {
            ResponseVM response = new() { Success = true };

            try
            {
                if (obj is MapShape mapShape)
                {
                    response.Success = false;
                    SetGeometry(mapShape, ref response);
                }

                if (response.Success)
                {
                    await db.MapObjects.AddAsync(obj);
                    await db.SaveChangesAsync();
                    response.Data = obj.ToGeoJSON();
                }

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseVM() { Msg = "Error saving object: " + ex.Message };
            }
        }

        public async Task<ResponseVM> EditObjectAsync(MapObject obj)
        {
            try
            {
                MapObject? dbObj = await db.MapObjects.FirstOrDefaultAsync(p => p.ID == obj.ID);

                if (dbObj == null)
                {
                    return new ResponseVM() { Msg = "Could not find map object" };
                }

                return await UpdateMapObjModel(obj, dbObj);
            }
            catch (Exception ex)
            {
                return new ResponseVM() { Msg = "Error updating object: " + ex.Message };
            }
        }

        public async Task<ResponseVM> DeleteObjectAsync(int id, string objType)
        {
            try
            {
                MapObject? dbObj = await db.MapObjects.FindAsync(id);

                if (dbObj == null)
                {
                    return new ResponseVM() { Msg = "Could not find map object" };
                }

                db.Remove(dbObj);
                await db.SaveChangesAsync();

                return new ResponseVM() { Success = true };
            }
            catch (Exception ex)
            {
                return new ResponseVM() { Msg = "Error saving delete changes: " + ex.Message };
            }
        }

        private static void SetGeometry(MapShape obj, ref ResponseVM response)
        {
            try
            {
                obj.ColorBytes = new ColorRgba(obj.Color);

                if (obj is not MapLine)
                {
                    obj.FillColorBytes = new ColorRgba(obj.FillColor);
                }

                if (obj is MapCircle circle)
                {
                    circle.SetArea();
                }
                else if (!string.IsNullOrWhiteSpace(obj.GeometryWKT))
                {
                    try
                    {
                        var ntsGeomServices = new NtsGeometryServices(new PrecisionModel(), 4326);
                        var geomFactory = ntsGeomServices.CreateGeometryFactory();
                        var reader = new WKTReader(ntsGeomServices);

                        var geom = reader.Read(obj.GeometryWKT);

                        if (!geom.IsValid)
                        {
                            var reason = new IsValidOp(geom).ValidationError?.Message;
                            response.Msg = $"Invalid geometry: {reason}";
                        }
                        else
                        {
                            if (geom is Polygon polygon && obj is MapPolygon poly)
                            {
                                poly.PolyGeometry = polygon;
                            }
                            else if (geom is LineString lineString && obj is MapLine line)
                            {
                                line.LineGeometry = lineString;
                            }
                            else
                            {
                                response.Msg = "Provided geometry is not a polygon.";
                            }
                        }

                    }
                    catch (ParseException ex)
                    {
                        response.Msg = $"WKT parsing error: {ex.Message}";
                    }
                }

                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Msg = "Error updataing object: " + ex.Message;
            }
        }

        private async Task<ResponseVM> UpdateMapObjModel(MapObject mapObj, MapObject dbMapObj)
        {
            try
            {
                dbMapObj.Name = mapObj.Name;
                dbMapObj.Notes = mapObj.Notes;

                if (mapObj is MapShape mapPoly && dbMapObj is MapShape dbMapPoly)
                {
                    dbMapPoly.Weight = mapPoly.Weight;
                    dbMapPoly.DashArray = mapPoly.DashArray;
                    dbMapPoly.ColorBytes = new ColorRgba(mapPoly.Color);
                    dbMapPoly.FillColorBytes = new ColorRgba(mapPoly.FillColor);
                }
                else if (mapObj is MapPoint point && dbMapObj is MapPoint dbPoint)
                {
                    dbPoint.IconID = point.IconID;
                    dbPoint.IconCollectionID = point.IconCollectionID;
                    dbPoint.Latitude = point.Latitude;
                    dbPoint.Longitude = point.Longitude;
                }

                await db.SaveChangesAsync();

                return new ResponseVM() { Success = true, Data = dbMapObj.ToGeoJSON() };
            }
            catch (Exception)
            {
                return new ResponseVM() { Msg = "Error saving changes." };
            }
        }
    }
}