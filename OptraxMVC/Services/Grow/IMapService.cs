using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Valid;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Maps;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Grow
{
    public interface IMapService
    {
        Task<Map?> GetMapAsync();
        Task<Map?> CreateMapAsync(Map map);
        Task<string> EditMapAsync(Map map);
        Task<JsonVM> GetObjectsAsync(string objType);
        Task<MapObject?> GetObjectAsync(int id, string objType);
        Task<string> CreateObjectAsync(MapObject obj);
        Task<MapObject?> EditObjectAsync(MapObject obj);
        Task<JsonVM> DeleteObjectAsync(int id, string objType);
    }

    public class MapService(OptraxContext context, ICurrentUserService user) : IMapService
    {
        private readonly OptraxContext db = context;
        private readonly string UserId = user.UserId;

        public async Task<Map?> GetMapAsync()
        {
            Map? dbMap = await db.Maps.Where(m => m.Active && m.UserId == UserId).FirstOrDefaultAsync();

            return dbMap ?? await CreateMapAsync(new Map("Default Map"));
        }

        public async Task<Map?> CreateMapAsync(Map map)
        {
            try
            {
                await db.Maps.AddAsync(map);
                await db.SaveChangesAsync();

                return map;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<string> EditMapAsync(Map map)
        {
            try
            {
                Map? dbMap = await db.Maps.Where(m => m.Id == map.Id && m.UserId == UserId).FirstOrDefaultAsync();

                if (dbMap == null)
                {
                    return "Map not found";
                }

                dbMap.Name = map.Name;
                dbMap.Details = map.Details;

                await db.SaveChangesAsync();

                return "OK";
            }
            catch (Exception ex)
            {
                return "Error saving map: " + ex.Message;
            }
        }

        public async Task<MapObject?> GetObjectAsync(int id, string objType)
        {
            MapObject? dbObj = await db.MapObjects.FindAsync(id);

            if (dbObj == null)
            {
                return null;
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

        public async Task<JsonVM> GetObjectsAsync(string objType)
        {
            try
            {
                var features = objType switch
                {
                    "Point" => (await db.MapPoints.Where(p => p.Active && p.UserId == UserId).Include(p => p.Icon).ToListAsync()).Select(p => p.ToGeoJSON()).ToList(),
                    "Line" => [.. (await db.MapLines.Where(p => p.Active && p.UserId == UserId).ToListAsync()).Select(p => p.ToGeoJSON())],
                    "Circle" => [.. (await db.MapCircles.Where(p => p.Active && p.UserId == UserId).ToListAsync()).Select(p => p.ToGeoJSON())],
                    "Polygon" => [.. (await db.MapPolygons.Where(p => p.Active && p.UserId == UserId).ToListAsync()).Select(p => p.ToGeoJSON())],
                    _ => throw new NotImplementedException()
                };

                object geoJson = new
                {
                    type = "FeatureCollection",
                    features
                };

                return new JsonVM(geoJson);
            }
            catch (Exception ex)
            {
                return new JsonVM("Error getting map objects: " + ex.Message);
            }
        }

        public async Task<string> CreateObjectAsync(MapObject obj)
        {
            JsonVM response = new(true);

            try
            {
                if (obj is MapShape mapShape)
                {
                    response.Success = false;
                    SetColorGeometry(mapShape, ref response);
                }

                if (response.Success)
                {
                    await db.MapObjects.AddAsync(obj);
                    await db.SaveChangesAsync();
                }

                return response.Success ? "OK" : response.Msg;
            }
            catch (Exception ex)
            {
                return "Error creating map object: " + ex.Message;
            }
        }

        public async Task<MapObject?> EditObjectAsync(MapObject obj)
        {
            try
            {
                MapObject? dbObj = await db.MapObjects.FirstOrDefaultAsync(p => p.Id == obj.Id);

                if (dbObj == null)
                {
                    return null;
                }

                return await MergeObjects(obj, dbObj);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<JsonVM> DeleteObjectAsync(int id, string objType)
        {
            try
            {
                MapObject? dbObj = await db.MapObjects.FindAsync(id);

                if (dbObj == null)
                {
                    return new JsonVM() { Msg = "Could not find map object" };
                }

                db.Remove(dbObj);
                await db.SaveChangesAsync();

                return new JsonVM() { Success = true };
            }
            catch (Exception ex)
            {
                return new JsonVM() { Msg = "Error saving delete changes: " + ex.Message };
            }
        }

        private static void SetColorGeometry(MapShape obj, ref JsonVM response)
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

        private async Task<MapObject?> MergeObjects(MapObject mapObj, MapObject dbMapObj)
        {
            try
            {
                dbMapObj.Name = mapObj.Name;
                dbMapObj.Details = mapObj.Details;

                if (mapObj is MapShape mapPoly && dbMapObj is MapShape dbMapPoly)
                {
                    JsonVM response = new(false);
                    SetColorGeometry(mapPoly, ref response);

                    if (!response.Success)
                    {
                        return null;
                    }
                    dbMapPoly.Weight = mapPoly.Weight;
                    dbMapPoly.DashArray = mapPoly.DashArray;
                    dbMapPoly.ColorBytes = mapPoly.ColorBytes;
                    dbMapPoly.FillColorBytes = mapPoly.FillColorBytes;

                    if (dbMapPoly is MapPolygon dbPoly && mapPoly is MapPolygon poly)
                    {
                        dbPoly.PolyGeometry = poly.PolyGeometry;
                    }
                    if (dbMapPoly is MapLine dbLine && mapPoly is MapLine line)
                    {
                        dbLine.LineGeometry = line.LineGeometry;
                    }
                }
                else if (mapObj is MapPoint point && dbMapObj is MapPoint dbPoint)
                {
                    dbPoint.IconId = point.IconId;
                    dbPoint.IconCollectionId = point.IconCollectionId;
                    dbPoint.Latitude = point.Latitude;
                    dbPoint.Longitude = point.Longitude;
                }

                await db.SaveChangesAsync();

                return dbMapObj;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}