using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Areas.Inventory.Models;
using OptraxMVC.Controllers;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class InventoryItemsController(OptraxContext context) : BaseController(context)
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetItems()
        {
            try
            {
                List<ItemVM> data = await db.Database.SqlQuery<ItemVM>($"GetItemsTableData").ToListAsync();

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(List<int> catIDs, string classType)
        {
            try
            {
                string view = "_EditCategory";
                object model = new InventoryCategory() { };

                if (classType == "Item")
                {
                    view = "_Edit";
                    model = new InventoryItem() { };

                    ViewBag.UOMs = await db.UOMs.ToListAsync();
                    ViewBag.StockTypes = Enum.GetValues(typeof(Enums.StockType));
                    ViewBag.Containers = await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
                }

                ViewBag.Categories = await db.InventoryCategories.Where(c => catIDs.Contains(c.ID)).Include(c => c.Parent).OrderBy(c => c.Parent.Name).ThenBy(c => c.Name).ToListAsync();

                return PartialView(view, model);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
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

                    ItemVM itemVM = new()
                    {
                        Cat0 = $"{cat0.Name}-{cat0.ID}-{cat0.HexColor}",
                        Cat1 = $"{cat1.Name}-{cat1.ID}-{cat1.HexColor}",
                        ItemID = newItem.ID,
                        ItemName = newItem.Name,
                        ItemDesc = newItem.Description,
                        SKU = newItem.SKU,
                        Brand = newItem.Manufacturer,
                        StockType = newItem.StockType,
                        UoM = newItem.DefaultUOM
                    };

                    return Json(new { success = true, data = itemVM });
                }

                return Json(new { success = false, msg = "Invalid Model" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(List<int> catIDs)
        {
            try
            {
                ViewBag.UOMs = await db.UOMs.ToListAsync();
                ViewBag.StockTypes = Enum.GetValues(typeof(Enums.StockType));
                ViewBag.Containers = await db.ContainerTypes.Where(c => c.Active).OrderBy(c => c.Name).ToListAsync();
                ViewBag.Categories = await db.InventoryCategories.Where(c => catIDs.Contains(c.ID)).Include(c => c.Parent).Select(c => new { c.ID, ListName = c.Parent.Name + " - " + c.Name }).OrderBy(d => d.ListName).ToListAsync();
                return PartialView($"_Edit", new InventoryItem() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(InventoryCategory cat)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    InventoryCategory newCat = cat;

                    db.InventoryCategories.Add(newCat);

                    await db.SaveChangesAsync();

                    return Json(new { success = true, id = newCat.ID, parentID = newCat.ParentID });
                }

                return Json(new { success = false, msg = "Invalid Model" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

    }
}
