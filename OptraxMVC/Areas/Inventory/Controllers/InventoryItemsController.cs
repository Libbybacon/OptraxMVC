using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventoryItemsController(OptraxContext context) : BaseController(context)
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<int> catIDs)
        {
            try
            {
                ViewBag.UOMs = await db.UOMs.ToListAsync();
                ViewBag.StockTypes = Enum.GetValues(typeof(Enums.StockType));
                ViewBag.Containers = await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
                ViewBag.Categories = await db.InventoryCategories.Where(c => catIDs.Contains(c.ID)).Include(c => c.Parent).Select(c => new { c.ID, ListName = c.Parent.Name + "-" + c.Name }).OrderBy(d => d.ListName).ToListAsync();
                return PartialView($"_Edit", new InventoryItem() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(InventoryItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InventoryItem newItem = item;

                    db.InventoryItems.Add(newItem);

                    await db.SaveChangesAsync();

                    return Json(new { success = true, itemID = newItem.ID, catID = newItem.CategoryID });
                }

                return Json(new { success = false, msg = "Invalid Model" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

    }
}
