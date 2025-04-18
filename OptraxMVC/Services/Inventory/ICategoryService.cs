﻿using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Models.ViewModels;

namespace OptraxMVC.Services.Inventory
{
    public interface ICategoryService
    {
        Task<bool> CheckNameAsync(string name);
        Task<Category?> GetCategoryByIdAsync(int id);
        Task<JsonVM> CreateAsync(Category cat);
        Task<JsonVM> UpdateAsync(Category cat);
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

        public async Task<JsonVM> CreateAsync(Category cat)
        {
            try
            {
                db.Categories.Add(cat);
                await db.SaveChangesAsync();

                return new JsonVM { Success = true, Msg = $"New {(!cat.ParentId.HasValue ? "top level " : "")}category '{cat.Name}' added!" };
            }
            catch (Exception)
            {
                return new JsonVM { Msg = "Error saving new category" };
            }
        }

        public async Task<JsonVM> UpdateAsync(Category cat)
        {
            try
            {
                var dbCat = await GetCategoryByIdAsync(cat.Id);

                if (dbCat == null)
                    return new JsonVM { Msg = "Category not found." };

                List<string> changes = cat.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(Category).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in InventoryCategory.");

                    prop.SetValue(dbCat, prop.GetValue(cat));
                }
                await db.SaveChangesAsync();

                return new JsonVM { Success = true, Msg = "Category changes saved!" };
            }
            catch (Exception)
            {
                return new JsonVM { Msg = "Error saving category :(" };
            }
        }
    }
}
