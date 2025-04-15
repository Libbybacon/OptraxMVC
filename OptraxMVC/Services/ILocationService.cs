using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models.ViewModels;

namespace OptraxMVC.Services
{
    public interface ILocationService
    {
        Task<List<object>> GetTreeNodesAsync();
        Task<Site?> GetSiteLocationAsync();
        Task<Location?> GetLocationAsync(int id, string type);
        Task<Location?> CreateAsync(Location loc);
        Task<string> EditAsync(Location loc);
        Task<JsonVM> DeleteAsync(int id);
    }

    public class LocationService(OptraxContext context, ICurrentUserService user, IMapper mapper) : ILocationService
    {
        private readonly string UserId = user.UserId;
        private readonly IMapper _Mapper = mapper;
        private readonly OptraxContext db = context;

        public async Task<Site?> GetSiteLocationAsync()
        {
            return (await db.Sites.Where(l => l.IsPrimary && l.UserId == UserId).Include(l => l.Address).FirstOrDefaultAsync()) ?? null;
        }

        public async Task<List<object>> GetTreeNodesAsync()
        {
            return [.. (await db.Locations.Where(l => l.Active && l.UserId == UserId).ToListAsync()).Select(l => l.ToTreeNode())];
        }

        public async Task<Location?> GetLocationAsync(int id, string type)
        {
            Location? dbLoc = null;

            if (type.Equals("site", StringComparison.CurrentCultureIgnoreCase))
            {
                dbLoc = await db.Sites.Where(l => l.Id == id && l.UserId == UserId).Include(l => l.Address).FirstOrDefaultAsync() ?? null;
            }
            else
            {
                dbLoc = await db.Locations.Where(l => l.Id == id && l.UserId == UserId).FirstOrDefaultAsync() ?? null;
            }

            return dbLoc;
        }

        public async Task<Location?> CreateAsync(Location newLoc)
        {
            try
            {
                await db.Locations.AddAsync(newLoc);
                await db.SaveChangesAsync();

                return newLoc;
            }
            catch (Exception ex)
            {
                //return new JsonVM { Msg = "Error saving new location..." + ex.Message };
                return null;
            }
        }

        public async Task<string> EditAsync(Location viewLoc)
        {
            try
            {
                Location? dbLoc = await db.Locations.FindAsync(viewLoc.Id);

                if (dbLoc == null) { return "Location not found"; }

                UpdateFields(viewLoc, dbLoc);

                await db.SaveChangesAsync();

                return "OK";
            }
            catch (Exception ex)
            {
                return "Error deleting location..." + ex.Message;
            }
        }

        private void UpdateFields(Location viewLoc, Location dbLoc)
        {
            dbLoc.Name = viewLoc.Name;
            dbLoc.Details = viewLoc.Details;
            dbLoc.ParentId = viewLoc.ParentId;
            dbLoc.LocationType = viewLoc.LocationType;

            dbLoc.IconId = viewLoc.IconId;
            dbLoc.MapObjectId = viewLoc.MapObjectId;

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
            Address? dbAdd = dbLoc.AddressId == null ? new() : db.Addresses.Find(dbLoc.AddressId);

            if (dbAdd != null)
            {
                _Mapper.Map(viewLoc.Address, dbAdd);
                Console.WriteLine($"Mapped Address.Lat: {dbAdd.Latitude}, Lng: {dbAdd.Longitude}");
                if (dbLoc.AddressId == null)
                {
                    db.Addresses.Add(dbAdd);
                }
                else
                {
                    db.Entry(dbAdd).State = EntityState.Modified;
                }

            }
            dbLoc.Address = dbAdd;
        }

        private static void UpdateDimensions(AreaLocation viewLoc, AreaLocation dbLoc)
        {
            dbLoc.Length = viewLoc.Length;
            dbLoc.Width = viewLoc.Width;
            dbLoc.Radius = viewLoc.Radius;
        }

        public async Task<JsonVM> DeleteAsync(int id)
        {
            try
            {
                Location? dbLoc = await db.Locations.Where(l => l.Id == id && l.UserId == UserId).FirstOrDefaultAsync();

                if (dbLoc == null)
                {
                    return new JsonVM("Error deleting location:  Could not find location");
                }
                dbLoc.Active = false;

                await db.SaveChangesAsync();
                return new JsonVM(true);
            }
            catch (Exception ex)
            {
                return new JsonVM("Error deleting location..." + ex.Message);
            }
        }
    }
}