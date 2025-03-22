using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using NetTopologySuite.IO;
using OptraxDAL;
using OptraxDAL.Models.Map;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IMapService
    {
        Task<ResponseVM> GetObjectsAsync(string objType);
        Task<object?[]> GetObjectAsync(int id, string objType);
        Task<ResponseVM> CreateObjectAsync(MapObject obj);
        Task<ResponseVM> DeleteObjectAsync(int id, string objType);

        Task<ResponseVM> EditPointAsync(MapPoint point);
        Task<ResponseVM> EditLineAsync(MapLine line);
        Task<ResponseVM> EditCircleAsync(MapCircle line);
        Task<ResponseVM> EditPolyAsync(MapPolygon poly);

    }

    public class MapService(OptraxContext context) : IMapService
    {
        private readonly OptraxContext db = context;

        public async Task<ResponseVM> GetObjectsAsync(string objType)
        {
            return objType switch
            {
                "point" => await GetPointsAsync(),
                "line" => await GetLinesAsync(),
                "circle" => await GetCirclesAsync(),
                _ => await GetPolygonsAsync(),
            };
        }

        public async Task<object?[]> GetObjectAsync(int id, string objType)
        {
            return objType switch
            {
                "point" => ["Point", await GetPointAsync(id)],
                "line" => ["Line", await GetLineAsync(id)],
                "circle" => ["Line", await GetCircleAsync(id)],
                _ => ["Polygon", await GetPolygonAsync(id)],
            };
        }

        public async Task<ResponseVM> CreateObjectAsync(MapObject obj)
        {
            return obj switch
            {
                MapPoint => await CreatePointAsync((MapPoint)obj),
                MapLine => await CreateLineAsync((MapLine)obj),
                MapPolygon => await CreatePolyAsync((MapPolygon)obj),
                MapCircle => await CreateCircleAsync((MapCircle)obj),
                _ => throw new NotImplementedException()
            };
        }

        public async Task<ResponseVM> DeleteObjectAsync(int id, string objType)
        {
            return objType switch
            {
                "point" => await DeletePointAsync(id),
                "line" => await DeleteLineAsync(id),
                "circle" => await DeleteCircleAsync(id),
                _ => await DeletePolyAsync(id),
            };
        }

        #region Points
        private async Task<ResponseVM> GetPointsAsync()
        {
            try
            {
                var points = await db.MapPoints
                    .Where(p => p.Active)
                    .Include(p => p.Icon)
                    .Select(p => new
                    {
                        type = "Feature",
                        properties = new
                        {
                            id = p.ID,
                            name = p.Name,
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
                    features = points
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
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error saving Point" };
            }
        }

        private async Task<MapPoint?> GetPointAsync(int pointID)
        {
            MapPoint? point = await db.MapPoints.Include(p => p.Icon).FirstOrDefaultAsync(p => p.ID == pointID);

            return point;
        }

        public async Task<ResponseVM> EditPointAsync(MapPoint point)
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
                var lines = await db.MapLines.Where(l => l.Active)
                                             .Select(l => new
                                             {
                                                 type = "Feature",
                                                 properties = new
                                                 {
                                                     id = l.ID,
                                                     name = l.Name,
                                                     style = new
                                                     {
                                                         color = l.Color,
                                                         width = l.Width,
                                                         pattern = l.Pattern,
                                                         dashArray = l.DashArray,
                                                     }
                                                 },
                                                 geometry = new
                                                 {
                                                     type = "polyline",
                                                     coordinates = l.LineGeometry!.Coordinates.Select(c => new[] { c.X, c.Y })
                                                 }
                                             }).ToListAsync();

                var geoJson = new
                {
                    type = "FeatureCollection",
                    features = lines
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
                    var reader = new WKTReader();
                    line.LineGeometry = (LineString)reader.Read(line.LineGeometryWKT);
                }

                await db.MapLines.AddAsync(line);
                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, data = line, function = "createSuccess" };
            }
            catch (Exception)
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
                var circles = await db.MapCircles.Where(c => c.Active)
                                             .Select(c => new
                                             {
                                                 type = "Feature",
                                                 properties = new
                                                 {
                                                     style = new
                                                     {
                                                         radius = c.Radius,
                                                         color = c.BorderColor,
                                                         weight = c.BorderWidth,
                                                         fillColor = c.FillColor,
                                                         dashArray = c.DashArray,
                                                     },
                                                     id = c.ID,
                                                     name = c.Name,
                                                     center = new[] { c.Longitude, c.Latitude },
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
                    features = circles
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
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error saving Circle" };
            }
        }

        private async Task<MapCircle?> GetCircleAsync(int circleID)
        {
            MapCircle? circle = await db.MapCircles.FirstOrDefaultAsync(c => c.ID == circleID);

            return circle;
        }

        public async Task<ResponseVM> EditCircleAsync(MapCircle circle)
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
                var polys = await db.MapPolygons.Where(p => p.Active)
                                                .Select(p => new
                                                {
                                                    type = "Feature",
                                                    properties = new
                                                    {
                                                        style = new
                                                        {
                                                            id = p.ID,
                                                            name = p.Name,
                                                            borderColor = p.BorderColor,
                                                            borderWidth = p.BorderWidth,
                                                            fillColor = p.FillColor,
                                                            pattern = p.Pattern,
                                                        },
                                                    },
                                                    geometry = new
                                                    {
                                                        type = "polygon",
                                                        coordinates = new[] {
                                                            p.PolyGeometry!.Coordinates.Select(coord => new[] { coord.X, coord.Y }).ToArray()
                                                        }
                                                    }
                                                }).ToListAsync();

                var geoJson = new
                {
                    type = "FeatureCollection",
                    features = polys
                };

                return new ResponseVM { success = true, data = geoJson };
            }
            catch (Exception ex)
            {
                return new ResponseVM { msg = "Error getting map objects" };
            }
        }

        private async Task<ResponseVM> CreatePolyAsync(MapPolygon poly)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(poly.PolyGeometryWKT))
                {
                    var reader = new WKTReader();
                    poly.PolyGeometry = (Polygon)reader.Read(poly.PolyGeometryWKT);
                }

                await db.MapPolygons.AddAsync(poly);
                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, data = poly, function = "createSuccess" };
            }
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error saving Poly" };
            }
        }

        private async Task<MapPolygon?> GetPolygonAsync(int polyID)
        {
            MapPolygon? poly = await db.MapPolygons.FirstOrDefaultAsync(p => p.ID == polyID);

            return poly;
        }

        public async Task<ResponseVM> EditPolyAsync(MapPolygon poly)
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