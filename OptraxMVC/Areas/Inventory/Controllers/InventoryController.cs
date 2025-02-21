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
        public class InvUpdateVM
        {
            public int ID { get; set; } = 0;
            public required string Field { get; set; }
            public required string Value { get; set; }
            public required string ClassType { get; set; }
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(InventoryItem invItem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InventoryItem newItem = invItem;

                    db.InventoryItems.Add(newItem);

                    await db.SaveChangesAsync();

                    return Json(new { success = true, itemID = newItem.ID });
                }

                return Json(new { success = false, msg = "Invalid Model" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> UpdateAttribute(InvUpdateVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.ClassType == "category")
                    {
                        InventoryCategory? cat = await db.InventoryCategories.FindAsync(model.ID);

                        if (cat != null)
                        {
                            var property = typeof(InventoryCategory).GetProperty(model.Field);

                            property?.SetValue(cat, model.Value);
                        }
                    }
                    else if (model.ClassType == "item")
                    {
                        InventoryItem? item = await db.InventoryItems.FindAsync(model.ID);

                        if (item != null)
                        {
                            var property = typeof(InventoryItem).GetProperty(model.Field);

                            property?.SetValue(item, model.Value);
                        }
                    }

                    await db.SaveChangesAsync();

                    return Json(new { success = true });
                }
                return Json(new { success = false, message = "Invalid model" });
            }
            catch
            {
                return Json(new { success = false, message = $"Error updating {model.ClassType}" });

            }
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
