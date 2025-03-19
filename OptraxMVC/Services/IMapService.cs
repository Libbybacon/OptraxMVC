using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Map;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IMapService
    {
        Task<ResponseVM> CreatePointAsync(MapPoint point);
        Task<MapPoint> LoadNewPointAsync(decimal lat, decimal lng);
        Task<ResponseVM> GetMapObjectsAsync();
    }

    public class MapService(OptraxContext context) : IMapService
    {
        private readonly OptraxContext db = context;

        public async Task<ResponseVM> GetMapObjectsAsync()
        {
            try
            {
                var points = await db.MapPoints.Where(p => p.Active).Include(p => p.Icon).Select(p => new PointVM
                {
                    ID = p.ID,
                    Lat = p.Latitude,
                    Long = p.Longitude,
                    Name = p.Name,
                    Description = p.Notes,
                    IconPath = p.GetIconPath(),
                }).ToListAsync();

                return new ResponseVM { success = true, data = points };
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

                return new ResponseVM() { success = true, msg = "Point added" };
            }
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error saving Point" };
            }
        }
    }
}
