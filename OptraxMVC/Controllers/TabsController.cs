using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Controllers
{
    public class TabsController(OptraxContext context, IDropdownService dropdownService) : BaseController(context, dropdownService)
    {

        // TODO: Move to db table, allow users to customize display orders by rearraging tabs in view 
        private readonly Dictionary<string, List<string>> TabViews = new()
        {
            ["Grow"] = ["Rooms", "Crops", "Plants", "Genetics"],
            ["Inventory"] = ["Items", "Plants", "Products", "Locations", "Transfers"],
            ["Sales"] = [],
            ["Reports"] = [],
        };

        [Authorize]
        public IActionResult LoadTabs(string navarea)
        {
            TabsVM tabsVM = new()
            {
                Area = navarea,
                Tabs = [.. TabViews[navarea].Select(t =>
                new Tab() { Name = t, TabKey = $"{t[..3].ToLower()}-{t.ToLower()}" })]
            };

            return View("Tabs", tabsVM);
        }

        [HttpGet]
        public async Task<IActionResult> LoadTabContent(string area, string name)
        {
            var tabVM = new TabsVM() { Area = area, Tabs = [new Tab() { Name = name, TabKey = "" }] };
            var tab = tabVM.Tabs[0];
            tabVM.SetTabViewPath(tab);

            object? model = tabVM.Area switch
            {
                "Grow" => tab.Name switch
                {
                    "Rooms" => await db.RoomLocations.ToListAsync(),
                    "Crops" => await db.Crops.ToListAsync(),
                    "Plants" => await db.Plants.ToListAsync(),
                    "Genetics" => await db.Strains.OrderBy(s => s.Name).ToListAsync(),
                    _ => null
                },

                "Inventory" => tab.Name switch
                {               
                    "Products" => await db.Products.ToListAsync(),
                    "Stock" => await db.StockItems.ToListAsync(),
                    "Locations" => await db.InventoryLocations.Where(c => c.ParentID == null)
                                                              .Include(c => c.Children)
                                                              .ThenInclude(c => c.Children)
                                                              .ToListAsync(),
                    _ => null
                },
                _ => null
            };

            switch (tab.Name)
            {
                case "Items":
                case "Plants":
                    tab.ViewPath = $"~/Areas/Inventory/Views/{tab.Name}/_{tab.Name}.cshtml";                   
                    tab.ViewPath = $"~/Areas/Inventory/Views/{tab.Name}/_{tab.Name}.cshtml";
                    return PartialView(tab.ViewPath);
                default:
                    break;
            }

            if (model == null)
            {
                return NotFound();
            }



            return PartialView(tab.ViewPath, model);
        }
    }
}
