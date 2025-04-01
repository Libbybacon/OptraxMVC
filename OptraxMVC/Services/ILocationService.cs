using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface ILocationService
    {
        Task<List<object>> GetTreeNodesAsync();
        Task<Site?> GetSiteLocationAsync();
        Task<LocationVM?> GetLocationAsync(int id, string type);
        Task<ResponseVM> CreateAsync(Location loc);
        Task<ResponseVM> EditAsync(Location loc);
        Task<ResponseVM> DeleteAsync(int id);
    }

    public class LocationService(OptraxContext context, ICurrentUserService user, IMapper mapper) : ILocationService
    {
        private readonly string UserID = user.UserID;
        private readonly IMapper _Mapper = mapper;
        private readonly OptraxContext db = context;

        public async Task<Site?> GetSiteLocationAsync()
        {
            return (await db.Sites.Where(l => l.IsPrimary && l.UserID == UserID).Include(l => l.Address).FirstOrDefaultAsync()) ?? null;
        }

        public async Task<List<object>> GetTreeNodesAsync()
        {
            return [.. (await db.Locations.Where(l => l.Active && l.UserID == UserID).ToListAsync()).Select(l => l.ToTreeNode())];
        }

        public async Task<LocationVM?> GetLocationAsync(int id, string type)
        {
            Location? dbLoc = null;

            if (type.Equals("site", StringComparison.CurrentCultureIgnoreCase))
            {
                dbLoc = await db.Sites.Where(l => l.ID == id && l.UserID == UserID).Include(l => l.Address).FirstOrDefaultAsync() ?? null;
            }
            else
            {
                dbLoc = await db.Locations.Where(l => l.ID == id && l.UserID == UserID).FirstOrDefaultAsync() ?? null;
            }

            return dbLoc == null ? null : new(dbLoc);
        }

        public async Task<ResponseVM> CreateAsync(Location newLoc)
        {
            try
            {
                await db.Locations.AddAsync(newLoc);
                await db.SaveChangesAsync();

                return new ResponseVM() { Success = true, Data = newLoc.ToTreeNode() };
            }
            catch (Exception ex)
            {
                return new ResponseVM { Msg = "Error saving new location..." + ex.Message };
            }
        }

        public async Task<ResponseVM> EditAsync(Location viewLoc)
        {
            try
            {
                Location? dbLoc = await db.Locations.FindAsync(viewLoc.ID);

                if (dbLoc == null) { return new ResponseVM("Location not found"); }

                UpdateFields(viewLoc, dbLoc);

                await db.SaveChangesAsync();

                return new ResponseVM(true);
            }
            catch (Exception ex)
            {
                return new ResponseVM("Error deleting location..." + ex.Message);
            }
        }

        private void UpdateFields(Location viewLoc, Location dbLoc)
        {
            dbLoc.Name = viewLoc.Name;
            dbLoc.Details = viewLoc.Details;
            dbLoc.ParentID = viewLoc.ParentID;
            dbLoc.LocationType = viewLoc.LocationType;

            dbLoc.IconID = viewLoc.IconID;
            dbLoc.MapObjectID = viewLoc.MapObjectID;

            if (viewLoc is AddressLocation viewAdd && dbLoc is AddressLocation dbAdd)
            {
                UpdateAddress(viewAdd, dbAdd);
            }

            if (viewLoc is AreaLocation viewArea && dbLoc is AreaLocation dbArea)
            {
                UpdateDimensions(viewArea, dbArea);
            }
        }

        private void UpdateAddress(AddressLocation viewLoc, AddressLocation dbLoc)
        {
            Address? dbAdd = dbLoc.AddressID == null ? new() : db.Addresses.Find(dbLoc.AddressID);

            if (dbAdd != null)
            {
                _Mapper.Map(viewLoc.Address, dbAdd);
            }
            dbLoc.Address = dbAdd;
        }

        private static void UpdateDimensions(AreaLocation viewLoc, AreaLocation dbLoc)
        {
            dbLoc.Length = viewLoc.Length;
            dbLoc.Width = viewLoc.Width;
            dbLoc.Radius = viewLoc.Radius;
        }

        public async Task<ResponseVM> DeleteAsync(int id)
        {
            try
            {
                Location? dbLoc = await db.Locations.Where(l => l.ID == id && l.UserID == UserID).FirstOrDefaultAsync();

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
    }
}


//private string GetParentString(int parentID)
//{
//    StringResult? parentString = db.Database.SqlQuery<StringResult>($"EXEC GetLocParentsString {parentID}").AsEnumerable().FirstOrDefault();

//    return parentString?.Value ?? string.Empty;
//}