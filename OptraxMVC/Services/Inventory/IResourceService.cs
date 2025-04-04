using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Inventory
{
    public interface IResourceService
    {
        Task<List<ResourceVM>> GetResourcesAsync();
        Task<Resource?> GetResourceByIdAsync(int rsrcId);
        Task<ResponseVM> CreateAsync(Resource rsrc);
        Task<ResponseVM> UpdateAsync(Resource rsrc);
        Task<Category[]?> GetResourceCategoriesAsync(int categoryId);
    }

    public class ResourceService(OptraxContext context) : IResourceService
    {
        private readonly OptraxContext db = context;

        public async Task<List<ResourceVM>> GetResourcesAsync()
        {
            return await db.Database.SqlQuery<ResourceVM>($"GetResourcesTableData").ToListAsync();
        }

        public async Task<Resource?> GetResourceByIdAsync(int rsrcId)
        {
            return await db.Resources.FindAsync(rsrcId);
        }

        public async Task<ResponseVM> CreateAsync(Resource rsrc)
        {
            var rsrcCats = await GetResourceCategoriesAsync(rsrc.CategoryId);

            if (rsrcCats == null)
                return new ResponseVM { Success = true, Msg = "Invalid category" };

            try
            {
                await db.Resources.AddAsync(rsrc);
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new ResponseVM { Success = false, Msg = "Error saving Resource" };
            }

            ResourceVM? rsrcVM = rsrc.ToResourceVM(rsrcCats[0], rsrcCats[1]);

            if (rsrcVM == null)
                return new ResponseVM { Success = false, Msg = "Error converting Resource" };

            return new ResponseVM { Success = false, Msg = "Resource Saved!", Data = rsrcVM };
        }

        public async Task<ResponseVM> UpdateAsync(Resource rsrc)
        {
            Resource? dbRsrc = await GetResourceByIdAsync(rsrc.Id);

            if (dbRsrc == null)
                return new ResponseVM { Msg = "Resource not found." };

            var rsrcCats = await GetResourceCategoriesAsync(dbRsrc.CategoryId);

            if (rsrcCats == null)
                return new ResponseVM { Msg = "Invalid category" };

            try
            {
                List<string> changes = rsrc.Changes?.Split(",")?.ToList() ?? [];

                foreach (string attrName in changes)
                {
                    var prop = typeof(Resource).GetProperty(attrName) ?? throw new InvalidOperationException($"Property '{attrName}' not found in Resource.");

                    prop.SetValue(dbRsrc, prop.GetValue(rsrc));
                }
                await db.SaveChangesAsync();
            }
            catch (Exception)
            {
                return new ResponseVM { Msg = "Error saving changes." };
            }

            ResourceVM rsrcVM = rsrc.ToResourceVM(rsrcCats[0], rsrcCats[1]);

            return new ResponseVM { Success = false, Msg = "Resource Updated!", Data = rsrcVM };
        }

        public async Task<Category[]?> GetResourceCategoriesAsync(int categoryId)
        {
            var cat1 = await db.Categories.Where(c => c.Id == categoryId).Include(c => c.Parent).FirstOrDefaultAsync();

            var cat0 = cat1?.Parent;

            return cat1 != null && cat0 != null ? [cat0, cat1] : null;
        }
    }
}
