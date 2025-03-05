using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Inventory;

namespace OptraxMVC.Services
{
    public interface IDropdownService
    {
        List<SelectListItem> GetUOMs();
        List<SelectListItem> GetStockTypes();
        List<SelectListItem> GetCategories();
        List<SelectListItem> GetTopCategories();
        List<ContainerType> GetContainerTypes();

    }

    public class DropdownService(OptraxContext context, IMemoryCache cache) : IDropdownService
    {
        private readonly OptraxContext db = context;
        private readonly IMemoryCache _cache = cache;

        public List<SelectListItem> GetUOMs()
        {
            return _cache.GetOrCreate("UOMs", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.UOMs?.Select(u => new SelectListItem
                {
                    Value = u.UnitName,
                    Text = u.ListName
                })
                .ToList() ?? [];
            }) ?? [];
        }

        public List<SelectListItem> GetStockTypes()
        {
            return [.. Enum.GetNames(typeof(Enums.StockType))
                           .Select(e => new SelectListItem
                           {
                               Value = e.ToString(),
                               Text = e.ToString()
                           })];
        }

        public List<SelectListItem> GetCategories()
        {
            return _cache.GetOrCreate("Categories", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.InventoryCategories?.Where(c => c.ParentID != null)
                                              .Include(c => c.Parent)
                                              .OrderBy(c => c.Parent.Name).ThenBy(c => c.Name)
                                              .Select(c => new SelectListItem
                                              {
                                                  Value = c.ID.ToString(),
                                                  Text = c.ListName
                                              })
                                              .ToList();
            }) ?? [];
        }

        public List<SelectListItem> GetTopCategories()
        {
            return _cache.GetOrCreate("TopCategories", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.InventoryCategories?.Where(c => c.ParentID == null).OrderBy(c => c.Name)
                                              .Select(c => new SelectListItem
                                              {
                                                  Value = c.ID.ToString(),
                                                  Text = c.Name
                                              })
                                              .ToList();
            }) ?? [];
        }

        public List<ContainerType> GetContainerTypes()
        {
            return _cache.GetOrCreate("ContainerTypes", entry =>
            {
                entry!.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10);

                return db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToList();
            }) ?? [];
        }
    }

}
