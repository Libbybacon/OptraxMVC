using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;
using OptraxMVC.Models;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventoryController(OptraxContext context) : BaseController(context)
    {
        public async Task<IActionResult> Index()
        {
            ViewBag.Categories = await db.InventoryCategories.Where(c => c.ParentID == null)
                                                             .Include(c => c.Children)
                                                             .ThenInclude(c => c.Children)
                                                             .ToListAsync() ?? [];
            return View();
        }

        public async Task<IActionResult> LoadTabContent(Tab tab)
        {
            object? model = tab.ShortName switch
            {
                "category" => await db.InventoryCategories.Where(c => c.ParentID == null)
                                                          .Include(c => c.Children)
                                                          .ThenInclude(c => c.Children)
                                                          .ToListAsync(),

                "item" => await db.InventoryItems.Include(i => i.StockItems).ToListAsync(),

                "stock" => await db.InventoryStockItems.ToListAsync(),

                "plant" => await db.Plants.ToListAsync(),

                "product" => await db.Products.ToListAsync(),

                "loc" => await db.InventoryLocations.Where(c => c.ParentID == null)
                                                    .Include(c => c.Children)
                                                    .ThenInclude(c => c.Children)
                                                    .ToListAsync(),
                //"equip" => await db.Equipment.ToListAsync(),
                //"transfer" => await db.Transfers.ToListAsync(),
                //"adjust" => await db.Adjustments.ToListAsync(),
                _ => null
            };

            if (model == null)
            {
                return NotFound();
            }

            return PartialView($"_{tab.ViewPath}", model);
        }

    }
}
