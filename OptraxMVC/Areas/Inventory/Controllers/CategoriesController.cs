using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Models.ViewModels;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class CategoriesController(OptraxContext context, IOptionsService optionsService, ICategoryService categoryService) : BaseController(context)
    {
        private readonly ICategoryService _ICategory = categoryService;
        private readonly IOptionsService _IOptions = optionsService;

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

                ViewData["Options"] = _IOptions.LoadOptions(["TopCatSelects"]);

                return PartialView("_Edit", new Category() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Category cat)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, errors = ModelState });

                if (await _ICategory.CheckNameAsync(cat.Name))
                    return Json(JsonVM("Duplicate Category Name."));

                JsonVM data = await _ICategory.CreateAsync(cat);
                return Json(data);


            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(int catId)
        {
            try
            {
                Category? category = await _ICategory.GetCategoryByIdAsync(catId);

                if (category == null)
                {
                    return Json(new { success = false, msg = "Category not found" });
                }


                ViewBag.FormVM = new FormVM()
                {
                    IsNew = false,
                    JsFunc = "editCategory",
                    Action = "Edit",
                    MsgDiv = "popupTopInner"
                };

                ViewData["Options"] = _IOptions.LoadOptions(["TopCatSelects"]);

                return PartialView("_Edit", category);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(Category cat)
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
