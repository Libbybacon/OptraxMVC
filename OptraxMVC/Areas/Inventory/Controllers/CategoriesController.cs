using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class CategoriesController(OptraxContext context, IDropdownService dropdownService) : BaseController(context, dropdownService)
    {
        [HttpPost]
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.Categories = await db.InventoryCategories.Where(c => c.ParentID == null).OrderBy(c => c.Name).ToListAsync();

                return PartialView("_EditCategory", new InventoryCategory() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(InventoryCategory cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InventoryCategory newCat = cat;

                    db.InventoryCategories.Add(newCat);

                    await db.SaveChangesAsync();

                    return Json(new { success = true });
                }

                return Json(new { success = false, errors = ModelState });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            var category = db.InventoryCategories.Find(id);
            if (category == null) return NotFound();

            category.Name = name;
            db.SaveChanges();

            return Json(new { success = true });
        }
    }
}
