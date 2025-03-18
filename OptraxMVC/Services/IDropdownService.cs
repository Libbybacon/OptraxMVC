using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.Models.Map;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IDropdownService
    {
        DropdownsVM LoadDropdowns(List<string> drops);
    }

    public class DropdownService(OptraxContext context, IMemoryCache cache) : IDropdownService
    {
        private readonly OptraxContext db = context;
        private readonly IMemoryCache _cache = cache;

        public DropdownsVM LoadDropdowns(List<string> drops)
        {
            DropdownsVM dropdownsVM = new()
            {
                UomSelects = drops.Contains("UomSelects") ? GetUomSelects() : [],
                StateSelects = drops.Contains("StateSelects") ? GetEnumSelects(typeof(Enums.States)) : [],
                ContainerTypeList = drops.Contains("ContainerTypeList") ? GetContainerTypesList() : [],

                IconsList = drops.Contains("IconsList") ? GetIconsList() : [],

                PlantTypeSelects = drops.Contains("PlantTypeSelects") ? GetEnumSelects(typeof(Enums.PlantType)) : [],
                PhaseSelects = drops.Contains("PhaseSelects") ? GetEnumSelects(typeof(Plant.PlantPhases)) : [],
                StrainsList = drops.Contains("StrainsList") ? GetStrainsList() : [],
                StrainSelects = drops.Contains("StrainSelects") ? GetStrainSelects() : [],
                OriginTypeSelects = drops.Contains("OriginTypeSelects") ? GetEnumSelects(typeof(Plant.OriginTypes)) : [],

                CategorySelects = drops.Contains("CategorySelects") ? GetCategorySelects() : [],
                TopCategorySelects = drops.Contains("TopCategorySelects") ? GetTopCatSelects() : [],
                StockTypeSelects = drops.Contains("StockTypeSelects") ? GetEnumSelects(typeof(Enums.StockType)) : [],

                LocationSelects = drops.Contains("LocationSelects") ? GetAllLocSelects() : [],
                RoomSelects = drops.Contains("RoomSelects") ? GetLocationByTypeSelects("Room") : [],
                BuildingSelects = drops.Contains("BuildingSelects") ? GetLocationByTypeSelects("Building") : [],
                OffSiteSelects = drops.Contains("OffSiteSelects") ? GetLocationByTypeSelects("Offsite") : [],
                ContainerLocSelects = drops.Contains("ContainerLocSelects") ? GetLocationByTypeSelects("Container") : [],
                LocationTypeSelects = drops.Contains("LocationTypeSelects") ? GetEnumSelects(typeof(Enums.LocationType)) : [],
            };

            return dropdownsVM;
        }

        private List<SelectListItem> GetEnumSelects(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("Provided type must be an enum.", nameof(enumType));

            return _cache.GetOrCreate($"{enumType.Name}EnumSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);


                return Enum.GetNames(enumType).Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() }).ToList() ?? [];
            }) ?? [];
        }

        private List<SelectListItem> GetUomSelects()
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

        private List<ContainerType> GetContainerTypesList()
        {
            return _cache.GetOrCreate("ContainerTypesSelect", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToList();
            }) ?? [];
        }

        private List<IconCollection> GetIconsList()
        {
            return _cache.GetOrCreate("IconsList", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.IconCollections.Include(i => i.Icons).OrderBy(c => c.Name).ToList();
            }) ?? [];
        }


        // Plants
        private List<SelectListItem> GetStrainSelects()
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

        private List<Strain> GetStrainsList()
        {
            return _cache.GetOrCreate("StrainsSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.Strains?.Where(c => c.Active).OrderBy(c => c.Name).ToList();
            }) ?? [];
        }


        // Inventory
        private List<SelectListItem> GetCategorySelects()
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

        private List<SelectListItem> GetTopCatSelects()
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


        // Locations
        private List<SelectListItem> GetAllLocSelects()
        {
            return _cache.GetOrCreate("AllLocationSelects", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.Locations?.Where(c => c.Active).OrderBy(c => c.Name).Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList();
            }) ?? [];
        }

        private List<SelectListItem> GetLocationByTypeSelects(string type)
        {
            return _cache.GetOrCreate($"{type}LocationSelects", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.Locations?.Where(c => c.LocationType == type && c.Active).OrderBy(c => c.Name).Select(c => new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Name
                }).ToList();
            }) ?? [];
        }
    }
}


