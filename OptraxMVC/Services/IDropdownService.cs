using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;

namespace OptraxMVC.Services
{
    public interface IDropdownService
    {
        List<SelectListItem> GetUomsList();
        List<SelectListItem> GetStatesList();
        List<ContainerType> GetContainerTypesList();

        List<SelectListItem> GetCategoriesList();
        List<SelectListItem> GetTopCategoriesList();

        // Locations
        Task<List<SelectListItem>> GetBuildings();
        Task<List<SelectListItem>> GetRooms();
        Task<List<SelectListItem>> GetContainerLocations();
        Task<List<SelectListItem>> GetOffsites();
        List<SelectListItem> GetLocationTypesList();
        List<SelectListItem> GetLocationsSelectList();

        // Plants
        List<Strain> GetStrains();
        List<SelectListItem> GetStrainsList();
        List<SelectListItem> GetPlantTypesList();
        List<SelectListItem> GetOriginTypesList();
        List<SelectListItem> GetStockTypesList();
        List<SelectListItem> GetGrowthPhasesList();
    }

    public class DropdownService(OptraxContext context, IMemoryCache cache) : IDropdownService
    {
        private readonly OptraxContext db = context;
        private readonly IMemoryCache _cache = cache;

        public List<SelectListItem> GetUomsList()
        {
            return _cache.GetOrCreate("UomsSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.UoMs?.Select(u => new SelectListItem
                {
                    Value = u.UnitName,
                    Text = u.ListName
                }).ToList();
            }) ?? [];
        }


        public List<SelectListItem> GetStockTypesList()
        {
            return [.. Enum.GetNames(typeof(Enums.StockType)).Select(e => new SelectListItem
                                                                          {
                                                                              Value = e.ToString(),
                                                                              Text = e.ToString()
                                                                          })];
        }

        public List<SelectListItem> GetCategoriesList()
        {
            return _cache.GetOrCreate("CategoriesSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.InventoryCategories.Where(c => c.ParentID != null)
                                             .Include(c => c.Parent)
                                             .Where(c => c.Parent != null)
                                             .OrderBy(c => c.Parent!.Name).ThenBy(c => c.Name)
                                             .Select(c => new SelectListItem
                                              {
                                                  Value = c.ID.ToString(),
                                                  Text = c.ListName
                                              }).ToList();
            }) ?? [];
        }

        public List<SelectListItem> GetTopCategoriesList()
        {
            return _cache.GetOrCreate("TopCategoriesSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.InventoryCategories?.Where(c => c.ParentID == null).OrderBy(c => c.Name)
                                              .Select(c => new SelectListItem
                                              {
                                                  Value = c.ID.ToString(),
                                                  Text = c.Name
                                              }).ToList();
            }) ?? [];
        }

        public List<ContainerType> GetContainerTypesList()
        {
            return _cache.GetOrCreate("ContainerTypesSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToList();
            }) ?? [];
        }

        // Plants
        public List<SelectListItem> GetGrowthPhasesList()
        {
            return [.. Enum.GetNames(typeof(Plant.PlantPhases)).Select(e => new SelectListItem
                                                                            {
                                                                                Value = e.ToString(),
                                                                                Text = e.ToString()
                                                                            })];
        }
        public List<SelectListItem> GetOriginTypesList()
        {
            return [.. Enum.GetNames(typeof(Plant.OriginTypes)).Select(e => new SelectListItem
                                                                            {
                                                                                Value = e.ToString(),
                                                                                Text = e.ToString().Replace("_", " - ")
                                                                            })];
        }
        public List<SelectListItem> GetPlantTypesList()
        {
            return [.. Enum.GetNames(typeof(Enums.PlantType)).Select(e => new SelectListItem
                                                                          {
                                                                              Value = e.ToString(),
                                                                              Text = e.ToString()
                                                                          })];
        }

        public List<Strain> GetStrains()
        {
            return _cache.GetOrCreate("StrainsSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.Strains?.Where(c => c.Active).OrderBy(c => c.Name).ToList();
            }) ?? [];
        }
        public List<SelectListItem> GetStrainsList()
        {
            return _cache.GetOrCreate("StrainsSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.Strains?.Where(c => c.Active).OrderBy(c => c.Name).Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList();
            }) ?? [];
        }


        // Locations
        public async Task<List<SelectListItem>> GetBuildings()
        {
            return await db.InventoryLocations.OfType<BuildingLocation>().OrderBy(c => c.Name).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetRooms()
        {
            return await db.InventoryLocations.OfType<RoomLocation>().OrderBy(c => c.Name).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetContainerLocations()
        {
            return await db.InventoryLocations.OfType<ContainerLocation>().OrderBy(c => c.Name).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToListAsync();
        }

        public async Task<List<SelectListItem>> GetOffsites()
        {
            return await db.InventoryLocations.OfType<OffsiteLocation>().OrderBy(c => c.Name).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToListAsync();
        }

        public List<SelectListItem> GetStatesList()
        {

            return [.. Enum.GetNames(typeof(Enums.States)).Select(e => new SelectListItem
                                                                          {
                                                                              Value = e.ToString(),
                                                                              Text = e.ToString()
                                                                          })];
        }

        public List<SelectListItem> GetLocationTypesList()
        {
            return [.. Enum.GetNames(typeof(Enums.LocationType)).Select(e => new SelectListItem
                                                                             {
                                                                                 Value = e.ToString(),
                                                                                 Text = e.ToString()
                                                                             })];
        }

        public List<SelectListItem> GetLocationsSelectList()
        {
            return _cache.GetOrCreate("LocationsSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.InventoryLocations?.Where(c => c.Active).OrderBy(c => c.Name).Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList();
            }) ?? [];
        }
    }
}


