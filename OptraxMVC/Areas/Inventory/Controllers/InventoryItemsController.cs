using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Controllers;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventoryItemsController(OptraxContext context) : BaseController(context)
    {
        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                List<ItemVM> data = await db.Database.SqlQuery<ItemVM>($"GetItemsTableData").ToListAsync();

                //var cats = await db.InventoryCategories.ToListAsync();
                //var listItems = new
                //{
                //    TopCats = cats.Where(c => c.ParentID == null).ToList(),
                //    ChildCats = cats.Where(c => c.ParentID != null).ToList(),
                //    Containers = await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync()
                //};

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(string classType)
        {
            try
            {
                string view = "_EditCategory";
                object model = new InventoryCategory() { };

                if (classType == "Item")
                {
                    view = "_Edit";
                    model = new InventoryItem() { };
                    ViewBag.IsNew = true;
                    ViewBag.UOMs = await db.UOMs.ToListAsync();
                    ViewBag.StockTypes = Enum.GetValues(typeof(Enums.StockType));
                    ViewBag.Containers = await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
                    ViewBag.Categories = await db.InventoryCategories.Where(c => c.ParentID.HasValue).Include(c => c.Parent).OrderBy(c => c.Parent.Name).ThenBy(c => c.Name).ToListAsync();
                }
                else
                {
                    ViewBag.Categories = await db.InventoryCategories.Where(c => c.ParentID == null).OrderBy(c => c.Name).ToListAsync();
                }

                return PartialView(view, model);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateItem(InventoryItem item)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InventoryItem newItem = item;
                    InventoryCategory? cat1 = await db.InventoryCategories.Where(c => c.ID == newItem.CategoryID).Include(c => c.Parent).FirstOrDefaultAsync();

                    var cat0 = cat1?.Parent;

                    if (cat1 == null || cat0 == null)
                    {
                        return Json(new { success = true, msg = "Invalid category" });
                    }

                    db.InventoryItems.Add(newItem);

                    await db.SaveChangesAsync();

                    ItemVM itemVM = newItem.ToItemVM(cat0, cat1);

                    return Json(new { success = true, data = itemVM });
                }

                return Json(new { success = false, errors = ModelState });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCategory(InventoryCategory cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InventoryCategory newCat = cat;

                    db.InventoryCategories.Add(newCat);

                    await db.SaveChangesAsync();

                    return Json(new { success = true });
                }

                return Json(new { success = false, errors = ModelState });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> ItemDetails(int itemID)
        {
            try
            {
                InventoryItem? item = await db.InventoryItems.FindAsync(itemID);

                if (item == null)
                {
                    return Json(new { success = false, msg = "Item not found" });
                }
                else
                {
                    //LoadItemViewBag();
                    ViewBag.IsNew = false;
                    ViewBag.UOMs = await db.UOMs.ToListAsync();
                    ViewBag.StockTypes = Enum.GetValues(typeof(Enums.StockType));
                    ViewBag.Containers = await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
                    ViewBag.Categories = await db.InventoryCategories.Where(c => c.ParentID.HasValue).Include(c => c.Parent).OrderBy(c => c.Parent.Name).ThenBy(c => c.Name).ToListAsync();
                    return PartialView("_Edit", item);
                }
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    msg = ex.Message
                });
            }
        }
    }
}
