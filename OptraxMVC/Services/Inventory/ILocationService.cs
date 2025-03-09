using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;

namespace OptraxMVC.Services.Inventory
{
    public interface ILocationService
    {
        Task<List<InventoryLocation>> GetLocationsAsync();
    }

    public class LocationService(OptraxContext context) : ILocationService
    {
        OptraxContext db = context;
       
        public async Task<List<InventoryLocation>> GetLocationsAsync() { 
        
            return await db.InventoryLocations.ToListAsync();
        }
    }
}
