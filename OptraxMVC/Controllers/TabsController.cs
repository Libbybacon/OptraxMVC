using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxMVC.Models;

namespace OptraxMVC.Controllers
{
    public class TabsController(OptraxContext context) : BaseController(context)
    {
        [Authorize]
        public IActionResult Index()
        {
            TabsVM tabs = new()
            {
                Area = "Grow",
                Tabs =
                [
                    new Tab() { Name = "Rooms", ShortName = "room" },
                    new Tab() { Name = "Crops", ShortName = "crop" },
                    new Tab() { Name = "Plants", ShortName = "plant" },
                    new Tab() { Name = "Strains", ShortName = "strain" },
                ]
            };
            return View("Tabs", tabs);
        }

        public async Task<IActionResult> LoadTabContentAsync(TabsVM tabVM)
        {
            var tab = tabVM.Tabs.First();

            object? model = tabVM.Area switch
            {
                "Grow" => tab.ShortName switch
                {
                    "room" => await db.Rooms.ToListAsync(),
                    "crop" => await db.Crops.ToListAsync(),
                    "plant" => await db.Plants.ToListAsync(),
                    "strain" => await db.Strains.ToListAsync(),
                    _ => null
                },

                "Inventory" => tab.ShortName switch
                {
                    "plant" => await db.Plants.ToListAsync(),
                    "product" => await db.Products.ToListAsync(),
                    "stock" => await db.InventoryStockItems.ToListAsync(),
                    "item" => await db.InventoryItems.Include(i => i.StockItems).ToListAsync(),

                    "loc" => await db.InventoryLocations.Where(c => c.ParentID == null)
                                                        .Include(c => c.Children)
                                                        .ThenInclude(c => c.Children)
                                                        .ToListAsync(),

                    "category" => await db.InventoryCategories.Where(c => c.ParentID == null)
                                                              .Include(c => c.Children)
                                                              .ThenInclude(c => c.Children)
                                                              .ToListAsync(),
                    _ => null
                },
                _ => null
            };

            if (model == null)
            {
                return NotFound();
            }

            tabVM.SetTabViewPath(tab);


            return PartialView(tab.ViewPath, model); // Dynamically load the correct partial view
        }
    }
}
