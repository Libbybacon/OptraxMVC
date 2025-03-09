using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Inventory
{
    public interface IItemService
    {
        Task<List<ItemVM>> GetItemsAsync();
        Task<InventoryItem?> GetItemByIdAsync(int itemID);
        Task<ResponseVM> CreateAsync(InventoryItem item);
        Task<ResponseVM> UpdateAsync(InventoryItem item);
        Task<InventoryCategory[]?> GetItemCategoriesAsync(int categoryId);

    }

    public class InventoryService(OptraxContext context) : IItemService
    {
        private readonly OptraxContext db = context;

        public async Task<List<ItemVM>> GetItemsAsync()
        {
            return await db.Database.SqlQuery<ItemVM>($"GetItemsTableData").ToListAsync();
        }

        public async Task<InventoryItem?> GetItemByIdAsync(int itemID)
        {
            return await db.InventoryItems.FindAsync(itemID);
        }

        public async Task<ResponseVM> CreateAsync(InventoryItem item)
        {
            var itemCats = await GetItemCategoriesAsync(item.CategoryID);

            if (itemCats == null)
                return new ResponseVM { success = true, msg = "Invalid category" };

            try
            {
                await db.InventoryItems.AddAsync(item);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new ResponseVM { success = false, msg = "Error saving item" };
            }

            ItemVM? itemVM = item.ToItemVM(itemCats[0], itemCats[1]);

            if (itemVM == null)
                return new ResponseVM { success = false, msg = "Error converting item" };

            return new ResponseVM { success = false, msg = "Item Saved!", data = itemVM };
        }

        public async Task<ResponseVM> UpdateAsync(InventoryItem item)
        {
            InventoryItem? dbItem = await GetItemByIdAsync(item.ID);

            if (dbItem == null)
                return new ResponseVM { msg = "Item not found." };

            var itemCats = await GetItemCategoriesAsync(dbItem.CategoryID);

            if (itemCats == null)
                return new ResponseVM { msg = "Invalid category" };

            try
            {
                List<string> changes = item.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(InventoryItem).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryItem.");

                    prop.SetValue(dbItem, prop.GetValue(item));
                }
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving changes." };
            }

            ItemVM itemVM = item.ToItemVM(itemCats[0], itemCats[1]);

            return new ResponseVM { success = false, msg = "Item Updated!", data = itemVM };
        }

        public async Task<InventoryCategory[]?> GetItemCategoriesAsync(int categoryId)
        {
            var cat1 = await db.InventoryCategories.Where(c => c.ID == categoryId).Include(c => c.Parent).FirstOrDefaultAsync();

            var cat0 = cat1?.Parent;

            return cat1 != null && cat0 != null ? [cat0, cat1] : null;
        }
    }
}
