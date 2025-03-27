using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface ILocationService
    {
        Task<List<object>> GetLocationsAsync();
        Task<LocationVM?> GetLocationAsync(int id);
        Task<ResponseVM> CreateAsync(LocationVM loc);
        //Task<ResponseVM> EditAsync(LocationVM loc);
        Task<ResponseVM> DeleteAsync(int id);
    }

    public class LocationService(OptraxContext context) : ILocationService
    {
        private readonly OptraxContext db = context;

        public async Task<List<object>> GetLocationsAsync()
        {

            return [.. (await db.Locations.ToListAsync()).Select(l => l.ToTreeNode())];
        }
        public async Task<LocationVM?> GetLocationAsync(int id)
        {
            Location? dbLoc = await db.Locations.FindAsync(id);

            return dbLoc == null ? null : new LocationVM(dbLoc);
        }

        public async Task<ResponseVM> DeleteAsync(int id)
        {
            try
            {
                Location? dbLoc = await db.Locations.FindAsync(id);

                if (dbLoc == null)
                {
                    return new ResponseVM("Error deleting location:  Could not find location");
                }

                dbLoc.Active = false;

                await db.SaveChangesAsync();
                return new ResponseVM(true);
            }
            catch (Exception ex)
            {
                return new ResponseVM("Error deleting location..." + ex.Message);
            }
        }
        public async Task<ResponseVM> CreateAsync(LocationVM locVM)
        {
            try
            {
                Location loc = locVM.LocationType.ToLower() switch
                {
                    "vehicle" => new VehicleLocation(),
                    "site" => new SiteLocation(locVM.Address, locVM.Business),
                    "greenhouse" => new GreenhouseLocation(),
                    "field" => new FieldLocation(),
                    "row" => new RowLocation(),
                    "bed" => new BedLocation(),
                    "plot" => new PlotLocation(),
                    "building" => new BuildingLocation(),
                    "room" => new RoomLocation(),
                    "offsite" => new OffsiteLocation(),
                    _ => new SiteLocation()
                };

                loc.Name = locVM.Name;
                loc.Details = locVM.Details;
                loc.ParentID = locVM.ParentID;

                await db.Locations.AddAsync(loc);
                await db.SaveChangesAsync();

                return new ResponseVM() { Success = true, Data = loc.ToTreeNode() };
            }
            catch (Exception)
            {
                return new ResponseVM { Msg = "Error saving new location..." };
            }
        }
    }
}
