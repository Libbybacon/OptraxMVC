using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace OptraxMVC.Services
{
    public interface IOptionsService
    {
        Task<OptionsVM> LoadOptions(List<string> drops, List<string>? types = null);
    }

    public class OptionsService(OptraxContext context, IMemoryCache cache) : IOptionsService
    {
        private readonly OptraxContext db = context;
        private readonly IMemoryCache _cache = cache;
        private readonly List<SelectListItem> EmptyList = [new SelectListItem() { Text = "No options available", Value = null }];

        public async Task<OptionsVM> LoadOptions(List<string> drops, List<string>? types)
        {
            OptionsVM dropdownsVM = new()
            {
                UomSelects = drops.Contains("UomSelects") ? GetUomSelects() : [],
                StateSelects = drops.Contains("StateSelects") ? GetEnumSelects(typeof(Enums.States)) : [],
                ContainerTypeList = drops.Contains("ContainerTypeList") ? await GetContainerTypesList() : [],

                IconsList = drops.Contains("IconsList") ? await GetIconsList() : [],

                PlantTypeSelects = drops.Contains("PlantTypeSelects") ? GetEnumSelects(typeof(Enums.PlantType)) : [],
                PhaseSelects = drops.Contains("PhaseSelects") ? GetEnumSelects(typeof(Plant.PlantPhases)) : [],
                CropsList = drops.Contains("StrainsList") ? await GetCropsList() : [],
                CropSelects = drops.Contains("StrainSelects") ? await GetCropSelects() : [],
                OriginTypeSelects = drops.Contains("OriginTypeSelects") ? GetEnumSelects(typeof(Plant.OriginTypes)) : [],

                CategorySelects = drops.Contains("CategorySelects") ? await GetCategorySelects() : [],
                TopCategorySelects = drops.Contains("TopCategorySelects") ? await GetTopCatSelects() : [],
                StockTypeSelects = drops.Contains("StockTypeSelects") ? GetEnumSelects(typeof(Enums.StockType)) : [],

                LocationSelects = drops.Contains("LocationSelects") ? await GetAllLocSelects() : [],
                LocSelectsByMultiTypes = drops.Contains("LocByTypeSelects") ? await GetLocSelectsByMultiTypes(types) : [],
                RoomSelects = drops.Contains("RoomSelects") ? await GetLocSelectsByType("Room") : [],
                BuildingSelects = drops.Contains("BuildingSelects") ? await GetLocSelectsByType("Building") : [],
                OffSiteSelects = drops.Contains("OffSiteSelects") ? await GetLocSelectsByType("Offsite") : [],
                ContainerLocSelects = drops.Contains("ContainerLocSelects") ? await GetLocSelectsByType("Container") : [],
                LocationTypeSelects = drops.Contains("LocationTypeSelects") ? GetEnumSelects(typeof(Enums.LocationType)) : [],
            };

            return dropdownsVM;
        }

        private static List<SelectListItem> GetEnumSelects(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Provided type must be an enum.", nameof(enumType));
            }

            return [.. Enum.GetValues(enumType).Cast<Enum>().Select(e => new SelectListItem
            {
                Value = e.ToString(),
                Text = e.GetType().GetMember(e.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.Name ?? e.ToString()
            })];
        }

        private List<SelectListItem> GetUomSelects()
        {
            return _cache.GetOrCreate("UomsSelect", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30);

                return db.UoMs?.Select(u => new SelectListItem
                {
                    Value = u.UnitName,
                    Text = u.ListName
                }).ToList();
            }) ?? [];
        }

        private async Task<List<ContainerType>> GetContainerTypesList()
        {
            return await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
        }

        private async Task<List<IconCollection>> GetIconsList()
        {
            return await db.IconCollections.Include(i => i.Icons).OrderBy(c => c.Name).ToListAsync();
        }


        // Plants
        private async Task<List<SelectListItem>> GetCropSelects()
        {
            return (await db.Crops.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        private async Task<List<Crop>> GetCropsList()
        {
            return await db.Crops.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
        }


        // Inventory
        private async Task<List<SelectListItem>> GetCategorySelects()
        {
            return (await db.Categories.Where(c => c.ParentID != null)
                                       .Include(c => c.Parent)
                                       .Where(c => c.Parent != null)
                                       .OrderBy(c => c.Parent!.Name).ThenBy(c => c.Name)
                                       .ToListAsync())
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.ID.ToString(),
                                           Text = c.ListName
                                       }).ToList() ?? EmptyList;

        }

        private async Task<List<SelectListItem>> GetTopCatSelects()
        {
            return (await db.Categories.Where(c => c.ParentID == null).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        // Locations
        private async Task<List<SelectListItem>> GetAllLocSelects()
        {
            return (await db.Locations.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        private async Task<List<SelectListItem>> GetLocSelectsByType(string type)
        {
            return (await db.Locations.Where(c => c.Active && c.LocationType == type).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        private async Task<List<SelectListItem>> GetLocSelectsByMultiTypes(List<string>? types)
        {
            if (types == null)
                return EmptyList;

            return (await db.Locations.Where(c => c.Active && types.Contains(c.LocationType)).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }
    }
}


