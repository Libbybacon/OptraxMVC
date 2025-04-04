using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Inventory
{
    public interface ICategoryService
    {
        Task<bool> CheckNameAsync(string name);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<ResponseVM> CreateAsync(Category cat);
        Task<ResponseVM> UpdateAsync(Category cat);
    }
    public class CategoryService(OptraxContext context) : ICategoryService
    {
        private readonly OptraxContext db = context;


        public async Task<bool> CheckNameAsync(string name)
        {
            return await db.Categories.Where(c => c.Name == name).FirstOrDefaultAsync() != null;
        }

        public async Task<Category?> GetCategoryByIdAsync(int id)
        {
            return await db.Categories.FindAsync(id);
        }

        public async Task<ResponseVM> CreateAsync(Category cat)
        {
            try
            {
                db.Categories.Add(cat);
                await db.SaveChangesAsync();

                return new ResponseVM { Success = true, Msg = $"New {(!cat.ParentId.HasValue ? "top level " : "")}category '{cat.Name}' added!" };
            }
            catch (Exception)
            {
                return new ResponseVM { Msg = "Error saving new category" };
            }
        }

        public async Task<ResponseVM> UpdateAsync(Category cat)
        {
            try
            {
                var dbCat = await GetCategoryByIdAsync(cat.Id);

                if (dbCat == null)
                    return new ResponseVM { Msg = "Category not found." };

                List<string> changes = cat.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(Category).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryCategory.");

                    prop.SetValue(dbCat, prop.GetValue(cat));
                }
                await db.SaveChangesAsync();

                return new ResponseVM { Success = true, Msg = "Category changes saved!" };
            }
            catch (Exception)
            {
                return new ResponseVM { Msg = "Error saving category :(" };
            }
        }
    }
}
