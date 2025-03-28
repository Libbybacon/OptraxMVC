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
        Task<SiteLocation?> GetSiteLocationAsync();
        Task<LocationVM?> GetLocationAsync(int id);
        Task<ResponseVM> CreateAsync(LocationVM loc);
        //Task<ResponseVM> EditAsync(LocationVM loc);
        Task<ResponseVM> DeleteAsync(int id);
    }

    public class LocationService(OptraxContext context, ICurrentUserService user) : ILocationService
    {
        private readonly OptraxContext db = context;
        private readonly string UserID = user.UserID;

        public async Task<SiteLocation?> GetSiteLocationAsync()
        {

            return (await db.SiteLocations.Where(l => l.IsPrimary && l.UserID == UserID).FirstOrDefaultAsync()) ?? null;
        }

        public async Task<List<object>> GetLocationsAsync()
        {

            return [.. (await db.Locations.Where(l => l.Active && l.UserID == UserID).ToListAsync()).Select(l => l.ToTreeNode())];
        }
        public async Task<LocationVM?> GetLocationAsync(int id)
        {
            Location? dbLoc = await db.Locations.FindAsync(id);

            return (dbLoc == null || dbLoc.UserID != UserID) ? null : new LocationVM(dbLoc);
        }

        public async Task<ResponseVM> DeleteAsync(int id)
        {
            try
            {
                Location? dbLoc = await db.Locations.FindAsync(id);

                if (dbLoc == null || dbLoc.UserID != UserID)
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
                    "site" => new SiteLocation(locVM.Address, locVM.Business) { IsPrimary = locVM.IsPrimary },
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
                loc.Level = locVM.Level;
                loc.Details = locVM.Details;
                loc.ParentID = locVM.ParentID;

                loc.IconID = locVM.IconID;
                loc.MapObjectID = locVM.MapObjectID;

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
