﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Extensions;
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
            ["Grow"] = ["Rooms", "Crops", "Plants", "Strains"],
            ["Inventory"] = ["Plants", "Products", "Stock", "Items", "Locations", "Categories"]
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

            return PartialView("_Tabs", tabsVM);
        }

        public async Task<IActionResult> LoadTabContentAsync(TabsVM tabVM)
        {
            var tab = tabVM.Tabs.First();

            object? model = tabVM.Area switch
            {
                "Grow" => tab.Name switch
                {
                    "Rooms" => await db.Rooms.ToListAsync(),
                    "Crops" => await db.Crops.ToListAsync(),
                    "Plants" => await db.Plants.ToListAsync(),
                    "Strains" => await db.Strains.ToListAsync(),
                    _ => null
                },

                "Inventory" => tab.Name switch
                {
                    "Plants" => await db.Plants.ToListAsync(),
                    "Products" => await db.Products.ToListAsync(),
                    "Stock" => await db.InventoryStockItems.ToListAsync(),
                    "Items" => await db.InventoryItems.Include(i => i.StockItems).ToListAsync(),

                    "Locations" => await db.InventoryLocations.Where(c => c.ParentID == null)
                                                        .Include(c => c.Children)
                                                        .ThenInclude(c => c.Children)
                                                        .ToListAsync(),

                    "Categories" => await db.InventoryCategories.Where(c => c.ParentID == null)
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

            return PartialView(tab.ViewPath, model);
        }
    }
}
