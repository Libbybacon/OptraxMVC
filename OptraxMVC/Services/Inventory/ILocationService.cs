using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Inventory
{
    public interface ILocationService
    {
        Task<List<InventoryLocation>> GetLocationsAsync();
        Task<ResponseVM> CreateAsync(InventoryLocation loc);
    }

    public class LocationService(OptraxContext context) : ILocationService
    {
        OptraxContext db = context;
       
        public async Task<List<InventoryLocation>> GetLocationsAsync() { 
        
            return await db.InventoryLocations.ToListAsync();
        }


        public async Task<ResponseVM> CreateAsync(InventoryLocation loc)
        {
            try
            {
                await db.InventoryLocations.AddAsync(loc);
                await db.SaveChangesAsync();

                return new ResponseVM {success = true, msg = "Location Added!", data = loc };
            }
            catch (Exception ex)
            {
                return new ResponseVM { msg = "Error saving new location..." };
            }
        }
    }
}
