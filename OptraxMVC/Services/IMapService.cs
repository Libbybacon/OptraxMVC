using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using NetTopologySuite.Operation.Valid;
using OptraxDAL;
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
            return objType switch
            {
                "Point" => await GetPointsAsync(),
                "Line" => await GetLinesAsync(),
                "Circle" => await GetCirclesAsync(),
                _ => await GetPolygonsAsync(),
            };
        }

        public async Task<object?> GetObjectAsync(int id, string objType)
        {
            return objType switch
            {
                "Point" => await GetPointAsync(id),
                "Line" => await GetLineAsync(id),
                "Circle" => await GetCircleAsync(id),
                _ => await GetPolygonAsync(id),
            };
        }

        public async Task<ResponseVM> CreateObjectAsync(MapObject obj)
        {
            return obj switch
            {
                MapPoint => await CreatePointAsync((MapPoint)obj),
                MapLine => await CreateLineAsync((MapLine)obj),
                MapCircle => await CreateCircleAsync((MapCircle)obj),
                MapPolygon => await CreatePolyAsync((MapPolygon)obj),
                _ => throw new NotImplementedException()
            };
        }

        public async Task<ResponseVM> EditObjectAsync(MapObject obj)
        {
            return obj switch
            {
                MapPoint => await EditPointAsync((MapPoint)obj),
                MapLine => await EditLineAsync((MapLine)obj),
                MapCircle => await EditCircleAsync((MapCircle)obj),
                MapPolygon => await EditPolyAsync((MapPolygon)obj),
                _ => throw new NotImplementedException()
            };
        }

        public async Task<ResponseVM> DeleteObjectAsync(int id, string objType)
        {
            return objType switch
            {
                "Point" => await DeletePointAsync(id),
                "Line" => await DeleteLineAsync(id),
                "Circle" => await DeleteCircleAsync(id),
                _ => await DeletePolyAsync(id),
            };
        }

        #region Points
        private async Task<ResponseVM> GetPointsAsync()
        {
            try
            {
                var features = await db.MapPoints.Where(p => p.Active)
                                                  .Include(p => p.Icon)
                                                  .Select(p => new
                                                  {
                                                      type = "Feature",
                                                      properties = new
                                                      {
                                                          id = p.ID,
                                                          name = p.Name,
                                                          objType = "Point",
                                                          iconPath = p.GetIconPath()
                                                      },
                                                      geometry = new
                                                      {
                                                          type = "Point",
                                                          coordinates = new[] { p.Longitude, p.Latitude }
                                                      }
                                                  }).ToListAsync();

                var geoJson = new
                {
                    type = "FeatureCollection",
                    features
                };

                return new ResponseVM { success = true, data = geoJson };
            }
            catch (Exception ex)
            {
                return new ResponseVM { msg = "Error getting map objects" };
            }
        }

        private async Task<ResponseVM> CreatePointAsync(MapPoint point)
        {
            try
            {
                await db.MapPoints.AddAsync(point);
                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, data = point, function = "createPointSuccess" };
            }
            catch (Exception ex)
            {
                return new ResponseVM() { msg = "Error saving Point" };
            }
        }

        private async Task<MapPoint?> GetPointAsync(int pointID)
        {
            MapPoint? point = await db.MapPoints.Include(p => p.Icon).FirstOrDefaultAsync(p => p.ID == pointID);

            return point;
        }

        private async Task<ResponseVM> EditPointAsync(MapPoint point)
        {
            MapPoint? dbPoint = await db.MapPoints.Include(p => p.Icon).FirstOrDefaultAsync(p => p.ID == point.ID);

            if (dbPoint == null)
            {
                return new ResponseVM { msg = "Could not find point" };
            }

            try
            {
                List<string> changes = point.Changes?.Split(",")?.Distinct()?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(MapPoint).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in Point.");

                    prop.SetValue(dbPoint, prop.GetValue(point));
                }
                await db.SaveChangesAsync();

                return new ResponseVM { success = true, data = point.ToPointVM(), function = "editPointSuccess" };

            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving changes." };
            }
        }

        private async Task<ResponseVM> DeletePointAsync(int id)
        {
            MapPoint? dbPoint = await db.MapPoints.FindAsync(id);

            if (dbPoint == null)
            {
                return new ResponseVM { msg = "Could not find point" };
            }

            db.Remove(dbPoint);
            await db.SaveChangesAsync();

            return new ResponseVM { success = true };
        }
        #endregion

        #region Lines
        private async Task<ResponseVM> GetLinesAsync()
        {
            try
            {
                var features = (await db.MapLines.Where(l => l.Active)
                                                 .ToListAsync())
                                                 .Select(l => new
                                                 {
                                                     type = "Feature",
                                                     properties = new
                                                     {
                                                         id = l.ID,
                                                         name = l.Name,
                                                         color = l.Color,
                                                         weight = l.Weight,
                                                         pattern = l.Pattern,
                                                         dashArray = l.DashArray,
                                                         objType = "Line",
                                                     },
                                                     geometry = new
                                                     {
                                                         type = "LineString",
                                                         coordinates = l.LineGeometry!.Coordinates.Select(c => new[] { c.X, c.Y })
                                                     }
                                                 }).ToList();

                var geoJson = new
                {
                    type = "FeatureCollection",
                    features
                };

                return new ResponseVM { success = true, data = geoJson };
            }
            catch (Exception ex)
            {
                return new ResponseVM { msg = "Error getting map objects" };
            }
        }

        private async Task<ResponseVM> CreateLineAsync(MapLine line)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(line.LineGeometryWKT))
                {
                    try
                    {
                        var ntsGeometryServices = new NtsGeometryServices(new PrecisionModel(), 4326);
                        var geometryFactory = ntsGeometryServices.CreateGeometryFactory();
                        var reader = new WKTReader(ntsGeometryServices);

                        var geom = reader.Read(line.LineGeometryWKT);

                        if (!geom.IsValid)
                        {
                            var reason = new IsValidOp(geom).ValidationError?.Message;
                            return new ResponseVM { msg = $"Invalid geometry: {reason}" };
                        }
                        else
                        {
                            line.LineGeometry = geom as LineString;
                        }
                    }
                    catch (ParseException ex)
                    {
                        return new ResponseVM { msg = $"WKT parsing error: {ex.Message}" };
                    }
                }

                await db.MapLines.AddAsync(line);
                await db.SaveChangesAsync();

                var geoLine = new
                {
                    type = "Feature",
                    properties = new
                    {
                        id = line.ID,
                        name = line.Name,
                        color = line.Color,
                        weight = line.Weight,
                        pattern = line.Pattern,
                        dashArray = line.DashArray,
                        objType = "Line",
                    },
                    geometry = new
                    {
                        type = "LineString",
                        coordinates = line.LineGeometry!.Coordinates.Select(c => new[] { c.X, c.Y })
                    }
                };
                return new ResponseVM() { success = true, data = geoLine, function = "createSuccess" };
            }
            catch (Exception ex)
            {
                return new ResponseVM() { msg = "Error saving Line" };
            }
        }

        private async Task<MapLine?> GetLineAsync(int lineID)
        {
            MapLine? line = await db.MapLines.FirstOrDefaultAsync(p => p.ID == lineID);

            return line;
        }

        public async Task<ResponseVM> EditLineAsync(MapLine line)
        {
            MapLine? dbLine = await db.MapLines.FirstOrDefaultAsync(p => p.ID == line.ID);

            if (dbLine == null)
            {
                return new ResponseVM { msg = "Could not find line" };
            }

            try
            {
                List<string> changes = line.Changes?.Split(",")?.Distinct()?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(MapLine).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in Line.");

                    prop.SetValue(dbLine, prop.GetValue(line));
                }
                await db.SaveChangesAsync();

                return new ResponseVM { success = true, data = line, function = "editLineSuccess" };

            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving changes." };
            }

        }

        private async Task<ResponseVM> DeleteLineAsync(int id)
        {
            MapLine? dbLine = await db.MapLines.FindAsync(id);

            if (dbLine == null)
            {
                return new ResponseVM { msg = "Could not find line" };
            }

            db.Remove(dbLine);
            await db.SaveChangesAsync();

            return new ResponseVM { success = true };
        }
        #endregion

        #region Circles
        private async Task<ResponseVM> GetCirclesAsync()
        {
            try
            {
                var features = await db.MapCircles.Where(c => c.Active)
                                                  .Select(c => new
                                                  {
                                                      type = "Feature",
                                                      properties = new
                                                      {
                                                          id = c.ID,
                                                          name = c.Name,
                                                          color = c.Color,
                                                          weight = c.Weight,
                                                          fillColor = c.FillColor,
                                                          dashArray = c.DashArray,
                                                          radius = c.Radius,
                                                          center = new[] { c.Longitude, c.Latitude },
                                                          objType = "Circle",
                                                      },
                                                      geometry = new
                                                      {
                                                          type = "point",
                                                          coordinates = new[] { c.Longitude, c.Latitude }
                                                      }
                                                  }).ToListAsync();

                var geoJson = new
                {
                    type = "FeatureCollection",
                    features
                };

                return new ResponseVM { success = true, data = geoJson };
            }
            catch (Exception ex)
            {
                return new ResponseVM { msg = "Error getting map objects" };
            }
        }

        private async Task<ResponseVM> CreateCircleAsync(MapCircle circle)
        {
            try
            {
                await db.MapCircles.AddAsync(circle);
                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, data = circle, function = "createSuccess" };
            }
            catch (Exception ex)
            {
                return new ResponseVM() { msg = "Error saving Circle" };
            }
        }

        private async Task<MapCircle?> GetCircleAsync(int circleID)
        {
            MapCircle? circle = await db.MapCircles.FirstOrDefaultAsync(c => c.ID == circleID);

            return circle;
        }

        private async Task<ResponseVM> EditCircleAsync(MapCircle circle)
        {
            MapCircle? dbCircle = await db.MapCircles.FirstOrDefaultAsync(c => c.ID == circle.ID);

            if (dbCircle == null)
            {
                return new ResponseVM { msg = "Could not find circle" };
            }

            try
            {
                List<string> changes = circle.Changes?.Split(",")?.Distinct()?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(MapCircle).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in Circle.");

                    prop.SetValue(dbCircle, prop.GetValue(circle));
                }
                await db.SaveChangesAsync();

                return new ResponseVM { success = true, data = circle, function = "editCircleSuccess" };

            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving changes." };
            }

        }

        private async Task<ResponseVM> DeleteCircleAsync(int id)
        {
            MapCircle? dbCircle = await db.MapCircles.FindAsync(id);

            if (dbCircle == null)
            {
                return new ResponseVM { msg = "Could not find circle" };
            }

            db.Remove(dbCircle);
            await db.SaveChangesAsync();

            return new ResponseVM { success = true };
        }
        #endregion

        #region Polygons
        private async Task<ResponseVM> GetPolygonsAsync()
        {
            try
            {
                var features = (await db.MapPolygons.Where(p => p.Active)
                                                    .ToListAsync())
                                                    .Select(p => new
                                                    {
                                                        type = "Feature",
                                                        properties = new
                                                        {
                                                            id = p.ID,
                                                            name = p.Name,
                                                            color = p.Color,
                                                            weight = p.Weight,
                                                            pattern = p.Pattern,
                                                            dashArray = p.DashArray,
                                                            fillColor = p.FillColor,
                                                            objType = "Polygon",
                                                        },
                                                        geometry = new
                                                        {
                                                            type = "Polygon",
                                                            coordinates = new[] { CloseRing(p.PolyGeometry!.Coordinates) }
                                                        }
                                                    }).ToList();
                var geoJson = new
                {
                    type = "FeatureCollection",
                    features
                };

                return new ResponseVM { success = true, data = geoJson };
            }
            catch (Exception ex)
            {
                return new ResponseVM { msg = "Error getting map objects" };
            }
        }

        private static double[][] CloseRing(Coordinate[] coords)
        {
            var points = coords.Select(c => new[] { c.X, c.Y }).ToList();

            if (!points.First().SequenceEqual(points.Last()))
            {
                points.Add(points.First());
            }

            return [.. points];
        }

        private async Task<ResponseVM> CreatePolyAsync(MapPolygon poly)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(poly.PolyGeometryWKT))
                {
                    try
                    {
                        var ntsGeometryServices = new NtsGeometryServices(new PrecisionModel(), 4326);
                        var geometryFactory = ntsGeometryServices.CreateGeometryFactory();
                        var reader = new WKTReader(ntsGeometryServices);

                        var geom = reader.Read(poly.PolyGeometryWKT);

                        if (!geom.IsValid)
                        {
                            var reason = new IsValidOp(geom).ValidationError?.Message;
                            return new ResponseVM { msg = $"Invalid geometry: {reason}" };
                        }
                        else
                        {
                            if (geom is Polygon polygon)
                            {
                                poly.PolyGeometry = polygon;
                            }
                            else
                            {
                                return new ResponseVM { msg = "Provided geometry is not a polygon." };
                            }
                        }
                    }
                    catch (ParseException ex)
                    {
                        return new ResponseVM { msg = $"WKT parsing error: {ex.Message}" };
                    }
                }

                await db.MapPolygons.AddAsync(poly);
                await db.SaveChangesAsync();

                var geoPoly = new
                {
                    type = "Feature",
                    properties = new
                    {
                        id = poly.ID,
                        name = poly.Name,
                        color = poly.Color,
                        weight = poly.Weight,
                        pattern = poly.Pattern,
                        dashArray = poly.DashArray,
                        fillColor = poly.FillColor,
                        objType = "Circle",
                    },
                    geometry = new
                    {
                        type = "Polygon",
                        coordinates = new[] { CloseRing(poly.PolyGeometry!.Coordinates) }
                    }
                };
                return new ResponseVM() { success = true, data = geoPoly, function = "createSuccess" };
            }
            catch (Exception ex)
            {
                return new ResponseVM() { msg = "Error saving Poly" };
            }
        }

        private async Task<MapPolygon?> GetPolygonAsync(int polyID)
        {
            MapPolygon? poly = await db.MapPolygons.FirstOrDefaultAsync(p => p.ID == polyID);

            return poly;
        }

        private async Task<ResponseVM> EditPolyAsync(MapPolygon poly)
        {
            MapPolygon? dbPoly = await db.MapPolygons.FirstOrDefaultAsync(p => p.ID == poly.ID);

            if (dbPoly == null)
            {
                return new ResponseVM { msg = "Could not find poly" };
            }

            try
            {
                List<string> changes = poly.Changes?.Split(",")?.Distinct()?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(MapPolygon).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in Poly.");

                    prop.SetValue(dbPoly, prop.GetValue(poly));
                }
                await db.SaveChangesAsync();

                return new ResponseVM { success = true, data = poly, function = "editPolySuccess" };

            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving changes." };
            }

        }

        private async Task<ResponseVM> DeletePolyAsync(int id)
        {
            MapPolygon? dbPoly = await db.MapPolygons.FindAsync(id);

            if (dbPoly == null)
            {
                return new ResponseVM { msg = "Could not find poly" };
            }

            db.Remove(dbPoly);
            await db.SaveChangesAsync();

            return new ResponseVM { success = true };
        }
        #endregion
    }
}