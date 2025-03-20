using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Map;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IMapService
    {
        Task<ResponseVM> GetPointsAsync();
        Task<MapPoint> LoadNewPointAsync(decimal lat, decimal lng);
        Task<ResponseVM> CreatePointAsync(MapPoint point);
        Task<MapPoint?> LoadEditPointAsync(int pointID);
        Task<ResponseVM> EditPointAsync(MapPoint point);

        Task<ResponseVM> GetLinesAsync();
        Task<MapLine> LoadNewLineAsync(string lineString);
        Task<ResponseVM> CreateLineAsync(MapLine line);
        Task<MapLine?> LoadEditLineAsync(int lineID);
        Task<ResponseVM> EditLineAsync(MapLine line);

        //Task<ResponseVM> GetPolysAsync();
        //Task<MapPolygon> LoadNewPolyAsync(decimal lat, decimal lng);
        //Task<ResponseVM> CreatePolyAsync(MapPolygon poly);
        //Task<MapPolygon?> LoadEditPolyAsync(int polyID);
        //Task<ResponseVM> EditPolyAsync(MapPolygon poly);
    }

    public class MapService(OptraxContext context) : IMapService
    {
        private readonly OptraxContext db = context;

        public async Task<ResponseVM> GetPointsAsync()
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

        public async Task<MapPoint> LoadNewPointAsync(decimal lat, decimal lng)
        {
            var icon = await db.Icons.Where(i => i.ID == 1).FirstOrDefaultAsync();

            MapPoint point = new()
            {
                Latitude = lat,
                Longitude = lng,
                IconPath = icon?.ImagePath ?? string.Empty
            };
            return point;
        }

        public async Task<ResponseVM> CreatePointAsync(MapPoint point)
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

        public async Task<MapPoint?> LoadEditPointAsync(int pointID)
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

        public async Task<ResponseVM> GetLinesAsync()
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
                                                     color = l.Color,
                                                     width = l.Width,
                                                     pattern = l.Pattern
                                                 },
                                                 geometry = new
                                                 {
                                                     type = "Line",
                                                     coordinates = l.LineGeometry.Coordinates.Select(c => new[] { c.X, c.Y })
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

        public MapLine LoadNewLineAsync(string lineString)
        {
            MapLine line = new()
            {
                LineString = lineString,
            };
            return new MapLine() { };
        }

        public async Task<ResponseVM> CreateLineAsync(MapLine point)
        {
            try
            {
                await db.MapLines.AddAsync(point);
                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, data = point, function = "createLineSuccess" };
            }
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error saving Line" };
            }
        }

        public async Task<MapLine?> LoadEditLineAsync(int lineID)
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
    }
}