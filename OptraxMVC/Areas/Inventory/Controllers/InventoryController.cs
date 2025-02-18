using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;

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


        [HttpPost]
        public async Task<IActionResult> AddCategory(string name, int? parentID)
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

            return PartialView("_ItemsChild", newCat);
        }

        [HttpPost]
        public async Task<IActionResult> EditCategory(int id, string name)
        {
            var category = await db.InventoryCategories.FindAsync(id);

            if (category == null) return NotFound();

            category.Name = name;

            await db.SaveChangesAsync();

            return Json(new { success = true, name });
        }

        [HttpPost]
        public async Task<IActionResult> SetActiveStatus(int id, string modelType)
        {
            switch (modelType)
            {
                case "item":
                    var item = await db.InventoryItems.FindAsync(id);
                    if (item == null) return NotFound();

                    item.Active = !item.Active;
                    break;

                case "cat":
                    var cat = await db.InventoryCategories.FindAsync(id);
                    if (cat == null) return NotFound();

                    cat.Active = !cat.Active;
                    break;
                default:
                    return NotFound();
            }
            ;

            await db.SaveChangesAsync();

            return Json(new { success = true });
        }
    }
}
