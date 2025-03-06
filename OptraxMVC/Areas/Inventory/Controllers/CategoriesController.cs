using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class CategoriesController(OptraxContext context, IDropdownService dropdownService, ICategoryService categoryService) : BaseController(context, dropdownService)
    {
        private readonly ICategoryService _ICategory = categoryService;

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewBag.FormVM = new FormVM()
                {
                    IsNew = true,
                    JsFunc = "addCategory",
                    Action = "Create",
                    MsgDiv = "tableMsg"
                };

                ViewData["TopCategories"] = _IDropdowns.GetTopCategoriesList();

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
                    bool saved = await _ICategory.CreateCategoryAsync(cat);

                    var data = new
                    {
                        success = saved,
                        msg = saved ? $"New {(!cat.ParentID.HasValue ? "top level " : "")}category '{cat.Name}' added!"
                                    : "Error saving new category"
                    };
                    return Json(data);
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
                InventoryCategory? category = await _ICategory.GetCategoryByIdAsync(catID);

                if (category == null)
                {
                    return Json(new { success = false, msg = "Category not found" });
                }

                ViewData["TopCategories"] = _IDropdowns.GetTopCategoriesList();

                ViewBag.FormVM = new FormVM()
                {
                    IsNew = false,
                    JsFunc = "updateCategory",
                    Action = "Edit",
                    MsgDiv = "popupTopInner"
                };

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

                var dbCat = await _ICategory.GetCategoryByIdAsync(cat.ID);

                if (dbCat == null)
                    return Json(new { success = false, msg = "Category not found." });

                bool saved = await _ICategory.UpdateCategoryAsync(cat, dbCat);

                var data = new { success = saved, msg = saved ? "Category changes saved!" : "Error saving category :(" };

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}
