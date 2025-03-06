using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;

namespace OptraxMVC.Services.Inventory
{
    public interface IPlantService
    {
        Task<List<PlantVM>> GetPlantsAsync();
    }

    public class PlantService(OptraxContext context) : IPlantService
    {
        private readonly OptraxContext db = context;

        public async Task<List<PlantVM>> GetPlantsAsync()
        {
            return await db.Database.SqlQuery<PlantVM>($"GetPlantsTableData").ToListAsync();
        }
    }
}
