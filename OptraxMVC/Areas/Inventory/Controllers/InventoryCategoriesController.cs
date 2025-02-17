using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventoryCategoriesController(OptraxContext context) : BaseController(context)
    {
        [HttpPost]
        public IActionResult Add(string name)
        {
            var newCategory = new InventoryCategory { Name = name };
            db.InventoryCategories.Add(newCategory);
            db.SaveChanges();

            return PartialView("_CategoryRow", newCategory);  // Return the new category row partial
        }

        [HttpPost]
        public IActionResult Edit(int id, string name)
        {
            var category = db.InventoryCategories.Find(id);
            if (category == null) return NotFound();

            category.Name = name;
            db.SaveChanges();

            return Ok();  // Respond with success
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var category = db.InventoryCategories.Find(id);
            if (category == null) return NotFound();

            db.InventoryCategories.Remove(category);
            db.SaveChanges();

            return Ok();  // Respond with success
        }
        [HttpPost]
        public async Task<IActionResult> AddAsync(string name, int? parentID)
        {
            var cat = new InventoryCategory()
            {
                Name = name,
                ParentID = parentID
            };

            db.InventoryCategories.Add(cat);
            db.Entry(cat).State = EntityState.Added;
            await db.SaveChangesAsync();

            var newCat = await db.InventoryCategories.Include(c => c.Children).FirstOrDefaultAsync(c => c.ID == cat.ID);

            if (newCat == null)
            {
                return BadRequest("Category not found.");
            }

            return PartialView("_CategoryChildren", newCat);
        }

        [HttpPost]
        public async Task<IActionResult> EditAsync(int id, string name)
        {
            var category = await db.InventoryCategories.FindAsync(id);
            
            if (category == null) return NotFound();

            category.Name = name;

            await db.SaveChangesAsync();

            return Json(new { success = true, name });
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var category = await db.InventoryCategories.FindAsync(id);

            if (category == null) return NotFound();

            category.Active = false;

            await db.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
