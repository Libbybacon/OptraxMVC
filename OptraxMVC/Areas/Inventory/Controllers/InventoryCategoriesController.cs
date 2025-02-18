using Microsoft.AspNetCore.Mvc;
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
    }
}
