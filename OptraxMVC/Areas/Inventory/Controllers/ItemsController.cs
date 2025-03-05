using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class ItemsController(OptraxContext context, IDropdownService dropdownService, IInventoryService inventoryService)
    : BaseController(context, dropdownService)
    {
        private readonly IInventoryService _IInventory = inventoryService;

        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                var data = await _IInventory.GetItemsAsync();

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
                LoadViewData();
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
                {
                    return Json(new { success = false, errors = ModelState });
                }

                var itemCats = await _IInventory.GetItemCategoriesAsync(item.CategoryID);

                if (itemCats == null)
                {
                    return Json(new { success = true, msg = "Invalid category" });
                }

                ItemVM? itemVM = await _IInventory.CreateItemAsync(item, itemCats);

                if (itemVM == null)
                {
                    return Json(new { success = false, msg = "Error saving item" });
                }

                return Json(new { success = true, data = itemVM });

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
                InventoryItem? item = await _IInventory.GetItemByIdAsync(itemID);

                if (item == null)
                {
                    return Json(new { success = false, msg = "Item not found" });
                }

                LoadViewData();
                ViewBag.FormVM = new FormVM() { IsNew = false, JsFunc = "updateItem", Action = "Edit", MsgDiv = "popupTopInner" };

                return PartialView("_Edit", item);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InventoryItem item)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new { success = false, msg = "Invalid model" });

                InventoryItem? dbItem = await _IInventory.GetItemByIdAsync(item.ID);

                if (dbItem == null)
                {
                    return Json(new { success = false, msg = "Item not found." });
                }

                await _IInventory.UpdateItemAsync(item, dbItem);

                var itemCats = await _IInventory.GetItemCategoriesAsync(dbItem.CategoryID);
                if (itemCats == null)
                {
                    return Json(new { success = true, msg = "Invalid category" });
                }
                ItemVM itemVM = item.ToItemVM(itemCats[0], itemCats[1]);

                return Json(new { success = true, msg = "Item updated!", data = itemVM });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        private void LoadViewData()
        {
            ViewData["UOMs"] = _IDropdowns.GetUOMs();
            ViewData["StockTypes"] = _IDropdowns.GetStockTypes();
            ViewData["Categories"] = _IDropdowns.GetCategories();
            ViewData["Containers"] = _IDropdowns.GetContainerTypes();
        }
    }
}
