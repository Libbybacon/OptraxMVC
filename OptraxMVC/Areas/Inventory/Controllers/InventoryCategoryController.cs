using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventoryCategoryController(OptraxContext context) : BaseController(context)
    {
        [HttpPost]
        public async Task<IActionResult> AddCategoryAsync(string name, int? parentID)
        {
            var cat = new InventoryCategory()
            {
                Name = name,
                ParentID = parentID
            };

            db.InventoryCategories.Add(cat);
            await db.SaveChangesAsync();

            var newCat = await db.InventoryCategories.Include(c => c.Children).FirstOrDefaultAsync(c => c.ID == cat.ID);

            if (newCat == null)
            {
                return BadRequest("Category not found.");
            }

            return PartialView("_CategoryTree", newCat);
        }
    }
}
