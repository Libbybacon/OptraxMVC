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
    public class ResourcesController(OptraxContext context, IDropdownService dropdownService, IResourceService resourceService)
    : BaseController(context)
    {
        private readonly IResourceService _IResource = resourceService;
        private readonly IDropdownService _IDropdowns = dropdownService;


        [HttpPost]
        public async Task<IActionResult> GetResources()
        {
            try
            {
                var data = await _IResource.GetResourcesAsync();

                LoadViewData();
                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            try
            {
                ViewData["Dropdowns"] = LoadViewData();
                ViewBag.FormVM = new FormVM() { IsNew = true, JsFunc = "addResource", Action = "Create", MsgDiv = "tableMsg" };
                return PartialView("_Edit", new Resource() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Resource rsrc)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, errors = ModelState });

                ResponseVM response = await _IResource.CreateAsync(rsrc);

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(int resourceID)
        {
            try
            {
                Resource? rsrc = await _IResource.GetResourceByIdAsync(resourceID);

                if (rsrc == null)
                {
                    return Json(new { success = false, msg = "Resource not found" });
                }

                ViewData["Dropdowns"] = LoadViewData();
                ViewBag.FormVM = new FormVM() { IsNew = false, JsFunc = "editResource", Action = "Edit", MsgDiv = "popupTopInner" };

                return PartialView("_Edit", rsrc);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Resource rsrc)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, msg = "Invalid model" });

                ResponseVM response = await _IResource.UpdateAsync(rsrc);

                return Json(response);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        private DropdownsVM LoadViewData()
        {
            return _IDropdowns.LoadDropdowns(["UomSelects", "StockTypeSelects", "CategorySelects", "ContainerTypeSelects"]);

        }
    }
}
