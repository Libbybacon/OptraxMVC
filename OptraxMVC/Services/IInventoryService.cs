using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;

namespace OptraxMVC.Services
{
    public interface IInventoryService
    {
        Task<List<ItemVM>> GetItemsAsync();
        Task<InventoryItem?> GetItemByIdAsync(int itemID);
        Task<ItemVM?> CreateItemAsync(InventoryItem item, InventoryCategory[] itemCats);
        Task<bool> UpdateItemAsync(InventoryItem item, InventoryItem dbItem);
        Task<InventoryCategory[]?> GetItemCategoriesAsync(int categoryId);

    }

    public class InventoryService(OptraxContext context) : IInventoryService
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

        public async Task<ItemVM?> CreateItemAsync(InventoryItem item, InventoryCategory[] itemCats)
        {
            try
            {
                db.InventoryItems.Add(item);

                await db.SaveChangesAsync();

                return item.ToItemVM(itemCats[0], itemCats[1]);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<bool> UpdateItemAsync(InventoryItem item, InventoryItem dbItem)
        {
            try
            {
                List<string> changes = item.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(InventoryItem).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryItem.");

                    prop.SetValue(dbItem, prop.GetValue(item));
                }
                await db.SaveChangesAsync();

                return true;
            }
            catch (Exception) { return false; }
        }

        public async Task<InventoryCategory[]?> GetItemCategoriesAsync(int categoryId)
        {
            var cat1 = await db.InventoryCategories.Where(c => c.ID == categoryId).Include(c => c.Parent).FirstOrDefaultAsync();

            var cat0 = cat1?.Parent;

            return (cat1 != null && cat0 != null) ? [cat0, cat1] : null;
        }


    }

}
