using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxMVC.Models;

namespace OptraxMVC.Controllers
{
    public class TabsController(OptraxContext context) : BaseController(context)
    {

        // TODO: Move to db table, allow users to customize display orders by rearraging tabs in view 
        private readonly Dictionary<string, List<string>> TabViews = new()
        {
            ["Grow"] = ["Map", "Locations", "Plants", "Genetics"],
            ["Inventory"] = ["Resources", "Transfers"],
            ["Settings"] = ["Collections", "Network", "User Management"],
            ["Sales"] = ["Products"],
            ["Reports"] = [],
        };

        [Authorize]
        public IActionResult LoadTabs(string navarea)
        {
            //TabsVM tabsVM = new()
            //{
            //    Area = navarea,
            //    Tabs = [.. TabViews[navarea].Select(tab =>
            //    new Tab() { Name = tab, TabKey = $"{tab[..3].ToLower()}-{tab.ToLower()}" })]
            //};
            TabsVM tabsVM = new()
            {
                Area = navarea,
                Tabs = [.. TabViews[navarea].Select(tab => new Tab(tab) { })]
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
                    "Genetics" => await db.Strains.OrderBy(s => s.Name).ToListAsync(),
                    _ => null
                },

                "Inventory" => tab.Name switch
                {
                    "Products" => await db.Products.ToListAsync(),
                    "Stock" => await db.StockItems.ToListAsync(),
                    _ => null
                },
                _ => null
            };

            switch (tab.Name)
            {
                case "Map":
                case "Resources":
                case "Plants":
                case "Locations":
                    tab.ViewPath = $"~/Areas/{area}/Views/{tab.Name}/_{tab.Name}.cshtml";
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
