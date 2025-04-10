using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using OptraxMVC.Models;

namespace OptraxMVC.Services
{
    public interface IOptionsService
    {
        Task<OptionsVM> LoadOptions(List<string> drops, int? level = 0, List<string>? types = null);
    }

    public class OptionsService(OptraxContext context) : IOptionsService
    {
        private readonly OptraxContext db = context;
        private readonly SelectListItem EmptyItem = new() { Text = "---- Select ----", Value = null };
        private readonly List<SelectListItem> EmptyList = [new SelectListItem()];

        public async Task<OptionsVM> LoadOptions(List<string> drops, int? level, List<string>? types)
        {
            OptionsVM optionsVM = new()
            {
                UomSelects = drops.Contains("UomSelects") ? await GetUomSelects() : [],
                StateSelects = drops.Contains("StateSelects") ? GetEnumSelects(typeof(Enums.States)) : [],
                ContainerTypeList = drops.Contains("ContainerTypeList") ? await GetContainerTypesList() : [],

                IconsList = drops.Contains("IconsList") ? await GetIconsList() : [],

                PlantSelects = drops.Contains("PlantSelects") ? await GetPlantSelects() : [],
                TaxonSelects = drops.Contains("TaxonSelects") ? GetEnumSelects(typeof(Enums.TaxonType)) : [],
                PlantTypeSelects = drops.Contains("PlantTypeSelects") ? GetEnumSelects(typeof(Enums.PlantType)) : [],

                CropsList = drops.Contains("CropsList") ? await GetCropsList() : [],
                CropSelects = drops.Contains("CropSelects") ? await GetCropSelects() : [],

                CatSelects = drops.Contains("CatSelects") ? await GetCatSelects() : [],
                TopCatSelects = drops.Contains("TopCatSelects") ? await GetTopCatSelects() : [],
                StockTypeSelects = drops.Contains("StockTypeSelects") ? GetEnumSelects(typeof(Enums.StockType)) : [],

                LocSelectsAll = drops.Contains("LocSelectsAll") ? await GetLocSelectsAll() : [],
                LocSelectsByType = drops.Contains("LocSelectsByType") ? await GetLocSelectsByType(types) : [],
                LocTypeSelects = drops.Contains("LocTypeSelects") ? GetEnumSelects(typeof(Enums.LocationType)) : [],
            };

            return optionsVM;
        }

        private List<SelectListItem> GetEnumSelects(Type enumType)
        {
            if (!enumType.IsEnum)
            {
                throw new ArgumentException("Provided type must be an enum.", nameof(enumType));
            }

            return Enum.GetNames(enumType).Select(e => new SelectListItem { Value = e.ToString(), Text = e.ToString() }).ToList() ?? EmptyList;


            //return [.. Enum.GetValues(enumType).Cast<Enum>().Select(e => new SelectListItem
            //{
            //    Value = e.ToString(),
            //    Text = e.GetType().GetMember(e.ToString()).First().GetCustomAttribute<DisplayAttribute>()?.Name ?? e.ToString()
            //})];
        }

        private async Task<List<SelectListItem>> GetUomSelects()
        {
            return (await db.UoMs.OrderBy(c => c.UnitName).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.UnitName,
                Text = c.ListName
            }).ToList() ?? EmptyList;
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
        private async Task<List<SelectListItem>> GetPlantSelects()
        {
            return (await db.Plants.Where(c => c.Active).OrderBy(c => c.CommonName).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.CommonName + "(" + c.ScientificName + ")"
            }).ToList() ?? EmptyList;
        }

        private async Task<List<SelectListItem>> GetCropSelects()
        {
            return (await db.Crops.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        private async Task<List<Crop>> GetCropsList()
        {
            return await db.Crops.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
        }


        // Inventory
        private async Task<List<SelectListItem>> GetCatSelects()
        {
            return (await db.Categories.Where(c => c.ParentId != null)
                                       .Include(c => c.Parent)
                                       .Where(c => c.Parent != null)
                                       .OrderBy(c => c.Parent!.Name).ThenBy(c => c.Name)
                                       .ToListAsync())
                                       .Select(c => new SelectListItem
                                       {
                                           Value = c.Id.ToString(),
                                           Text = c.ListName
                                       }).ToList() ?? EmptyList;

        }

        private async Task<List<SelectListItem>> GetTopCatSelects()
        {
            return (await db.Categories.Where(c => c.ParentId == null).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        // Locations
        private async Task<List<SelectListItem>> GetLocSelectsAll()
        {
            return (await db.Locations.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        private async Task<List<SelectListItem>> GetLocSelectsByType(List<string>? types)
        {
            if (types == null)
                return EmptyList;

            return (await db.Locations.Where(c => c.Active && types.Contains(c.LocationType)).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList() ?? EmptyList;
        }

        //private async Task<List<SelectListItem>> GetLocSelectsByLevel(int? level)
        //{
        //    if (level == null || level == 0)
        //        return EmptyList;

        //    int parentLevel = (int)level - 1;
        //    return (await db.Locations.Where(c => c.Active && c.Level == parentLevel).OrderBy(c => c.Name).ToListAsync()).Select(c => new SelectListItem
        //    {
        //        Value = c.Id.ToString(),
        //        Text = string.Format("{0} - {1}", c.Name, c.LocationType)
        //    }).ToList() ?? EmptyList;
        //}
    }
}


