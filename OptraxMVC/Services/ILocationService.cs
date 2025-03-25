using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsAsync();
        Task<ResponseVM> CreateAsync(Location loc);
    }

    public class LocationService(OptraxContext context) : ILocationService
    {
        private readonly OptraxContext db = context;

        public async Task<List<Location>> GetLocationsAsync()
        {

            return await db.Locations.ToListAsync();
        }

        public async Task<ResponseVM> CreateAsync(Location loc)
        {
            try
            {
                await db.Locations.AddAsync(loc);
                await db.SaveChangesAsync();

                return new ResponseVM { Success = true, Msg = "Location Added!", Data = loc };
            }
            catch (Exception)
            {
                return new ResponseVM { Msg = "Error saving new location..." };
            }
        }
    }
}
