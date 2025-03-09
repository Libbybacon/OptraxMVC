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
    public class CategoriesController(OptraxContext context, IDropdownService dropdownService, ICategoryService categoryService) : BaseController(context)
    {
        private readonly ICategoryService _ICategory = categoryService;
        private readonly IDropdownService _IDropdowns = dropdownService;

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
                if (!ModelState.IsValid)
                    return Json(new { success = false, errors = ModelState });

                if (await _ICategory.CheckNameAsync(cat.Name))
                    return Json(new { success = false, msg = "Duplicate Category Name." });

                ResponseVM data = await _ICategory.CreateAsync(cat);
                return Json(data);


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

                var data = await _ICategory.UpdateAsync(cat);

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}
