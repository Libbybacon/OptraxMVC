using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class CategoriesController(OptraxContext context, IDropdownService dropdownService) : BaseController(context, dropdownService)
    {
        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.FormVM = new FormVM() { IsNew = true, JsFunc = "addCategory", Action = "Create", MsgDiv = "tableMsg" };

                ViewData["TopCategories"] = _IDropdowns.GetTopCategories();

                return PartialView("_Edit", new InventoryCategory() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(InventoryCategory cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.InventoryCategories.Add(cat);

                    await db.SaveChangesAsync();

                    return Json(new { success = true, msg = $"New {(!cat.ParentID.HasValue ? "top level " : "")}category '{cat.Name}' added!" });
                }

                return Json(new { success = false, errors = ModelState });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(int catID)
        {
            try
            {
                var category = await db.InventoryCategories.FindAsync(catID);

                if (category == null)
                {
                    return Json(new { success = false, msg = "Category not found" });
                }

                ViewData["TopCategories"] = _IDropdowns.GetTopCategories();
                ViewBag.FormVM = new FormVM() { IsNew = false, JsFunc = "updateCategory", Action = "Edit", MsgDiv = "popupTopInner" };

                return PartialView("_Edit", category);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(InventoryCategory cat)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, msg = "Invalid model" });

                var dbCat = await db.InventoryCategories.FindAsync(cat.ID);

                if (dbCat == null)
                {
                    return Json(new { success = false, msg = "Category not found." });
                }

                List<string> changes = cat.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(InventoryCategory).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryCategory.");

                    prop.SetValue(dbCat, prop.GetValue(cat));
                }
                await db.SaveChangesAsync();

                return Json(new { success = true, msg = "Category updated!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}
