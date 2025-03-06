using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;

namespace OptraxMVC.Services.Inventory
{
    public interface ICategoryService
    {
        Task<InventoryCategory?> GetCategoryByIdAsync(int id);
        Task<bool> CreateCategoryAsync(InventoryCategory cat);
        Task<bool> UpdateCategoryAsync(InventoryCategory cat, InventoryCategory dbCat);
    }
    public class CategoryService(OptraxContext context) : ICategoryService
    {
        private readonly OptraxContext db = context;
        public async Task<InventoryCategory?> GetCategoryByIdAsync(int id)
        {
            return await db.InventoryCategories.FindAsync(id);
        }

        public async Task<bool> CreateCategoryAsync(InventoryCategory cat)
        {
            try
            {
                db.InventoryCategories.Add(cat);
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateCategoryAsync(InventoryCategory cat, InventoryCategory dbCat)
        {
            try
            {
                List<string> changes = cat.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(InventoryCategory).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryCategory.");

                    prop.SetValue(dbCat, prop.GetValue(cat));
                }
                await db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
