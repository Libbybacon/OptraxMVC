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
    }
}
