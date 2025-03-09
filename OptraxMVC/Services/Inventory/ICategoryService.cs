using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Inventory
{
    public interface ICategoryService
    {
        Task<bool> CheckNameAsync(string name); 
        Task<InventoryCategory?> GetCategoryByIdAsync(int id);
        Task<ResponseVM> CreateAsync(InventoryCategory cat);
        Task<ResponseVM> UpdateAsync(InventoryCategory cat);
    }
    public class CategoryService(OptraxContext context) : ICategoryService
    {
        private readonly OptraxContext db = context;


        public async Task<bool> CheckNameAsync(string name)
        {
            return await db.InventoryCategories.Where(c => c.Name == name).FirstOrDefaultAsync() != null;
        }

        public async Task<InventoryCategory?> GetCategoryByIdAsync(int id)
        {
            return await db.InventoryCategories.FindAsync(id);
        }

        public async Task<ResponseVM> CreateAsync(InventoryCategory cat)
        {
            try
            {
                db.InventoryCategories.Add(cat);
                await db.SaveChangesAsync();

                return new ResponseVM { success = true, msg = $"New {(!cat.ParentID.HasValue ? "top level " : "")}category '{cat.Name}' added!" };
            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving new category" };
            }
        }

        public async Task<ResponseVM> UpdateAsync(InventoryCategory cat)
        {
            try
            {
                var dbCat = await GetCategoryByIdAsync(cat.ID);

                if (dbCat == null)
                    return new ResponseVM { msg = "Category not found." };

                List<string> changes = cat.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(InventoryCategory).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryCategory.");

                    prop.SetValue(dbCat, prop.GetValue(cat));
                }
                await db.SaveChangesAsync();

                return new ResponseVM { success = true, msg = "Category changes saved!" };
            }
            catch (Exception)
            {
                return new ResponseVM { msg = "Error saving category :(" };
            }
        }
    }
}
