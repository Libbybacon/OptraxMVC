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
    public class ItemsController(OptraxContext context, IDropdownService dropdownService, IItemService itemService)
    : BaseController(context)
    {
        private readonly IItemService _IItem = itemService;
        private readonly IDropdownService _IDropdowns = dropdownService;


        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var data = await _IItem.GetItemsAsync();

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
                ViewBag.FormVM = new FormVM() { IsNew = true, JsFunc = "addItem", Action = "Create", MsgDiv = "tableMsg" };
                return PartialView("_Edit", new InventoryItem() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(InventoryItem item)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, errors = ModelState });

                ResponseVM response = await _IItem.CreateAsync(item);

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Details(int itemID)
        {
            try
            {
                InventoryItem? item = await _IItem.GetItemByIdAsync(itemID);

                if (item == null)
                {
                    return Json(new { success = false, msg = "Item not found" });
                }

                ViewData["Dropdowns"] = LoadViewData();
                ViewBag.FormVM = new FormVM() { IsNew = false, JsFunc = "updateItem", Action = "Edit", MsgDiv = "popupTopInner" };

                return PartialView("_Edit", item);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(InventoryItem item)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, msg = "Invalid model" });

                ResponseVM response = await _IItem.UpdateAsync(item);

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
