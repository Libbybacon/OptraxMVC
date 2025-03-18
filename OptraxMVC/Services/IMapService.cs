using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Map;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IMapService
    {
        Task<ResponseVM> AddPoint(MapPoint point);
        Task<MapPoint> LoadNewPointAsync(decimal lat, decimal lng);
    }

    public class MapService(OptraxContext context) : IMapService
    {
        private readonly OptraxContext db = context;

        public async Task<MapPoint> LoadNewPointAsync(decimal lat, decimal lng)
        {
            var icon = await db.Icons.Where(i => i.Active).FirstOrDefaultAsync();
            MapPoint point = new()
            {
                Latitude = lat,
                Longitude = lng,
                IconID = icon?.ID ?? 0,
                IconPath = icon?.ImagePath ?? string.Empty
            };

            return point;
        }

        public async Task<ResponseVM> AddPoint(MapPoint point)
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
