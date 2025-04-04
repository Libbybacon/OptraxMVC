using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;

namespace OptraxMVC.Services.Inventory
{
    public interface IPlantService
    {
        Task<Plant> LoadNewPlant(string UserId);
        Task<ResponseVM> GetParentListAsync(int strainId);
        Task<int> GetPlantInventoryIdAsync();
        Task<List<PlantVM>> GetPlantsAsync();
        Task<ResponseVM> CreateAsync(Plant plant, string userId);
    }

    [Authorize]
    public class PlantService(OptraxContext context) : IPlantService
    {
        private readonly OptraxContext db = context;

        [Authorize]
        public async Task<List<PlantVM>> GetPlantsAsync()
        {
            return await db.Database.SqlQuery<PlantVM>($"GetPlantsTableData").ToListAsync();
        }

        [Authorize]
        public async Task<Plant> LoadNewPlant(string UserId)
        {
            int inventoryId = await GetPlantInventoryIdAsync();

            var transfer = new InventoryTransfer()
            {
                Date = DateTime.Now,
                UserId = UserId,
                UnitCount = 1,
                UnitUoM = "Each",
                IsPartial = false,
                Status = "Initiated",
                NeedsApproval = false,
            };

            //Plant plant = new()
            //{
            //    PurchaseDate = DateTime.Now,
            //    ResourceId = inventoryId,
            //    PlantEvents = [
            //    new TransferEvent() {
            //            Date = DateTime.Now,
            //            EventType = "Transfer",
            //            UserId = UserId,
            //            Transfer = transfer
            //        }]
            //};

            //return plant;
            return new Plant();
        }

        [Authorize]
        public async Task<int> GetPlantInventoryIdAsync()
        {
            return await db.Resources.Where(i => i.Name == "Plant").Select(i => i.Id).FirstAsync();
        }

        //[Authorize]
        public async Task<ResponseVM> CreateAsync(Plant plant, string userId)
        {
            //    plant.Resource = await db.Resources.FindAsync(await GetPlantInventoryIdAsync());

            //    var strain = await db.Strains.FindAsync(plant.SpeciesId);

            //    if (strain == null)
            //        return new ResponseVM() { Msg = "Could not find Strain" };

            //    try
            //    {
            //        //Crop crop = await db.Crops.Where(c => c.BatchId == plant.Crop.BatchId).FirstOrDefaultAsync() ?? plant.Crop;

            //        //if (crop.StrainId != plant.SpeciesId)
            //        //    return new ResponseVM() { Msg = "Plant Strain does not match Crop Strain" };

            //        //plant.Crop = crop;
            //        ////crop.Strain = strain;
            //        ////plant.Strain = strain;

            //        //var mapper = new MapperConfiguration(cfg => cfg.AddProfile<PlantProfile>()).CreateMapper();

            //        //for (int i = 0; i < plant.Quantity; i++)
            //        //{
            //        //    var newPlant = mapper.Map<Plant>(plant);
            //        //    crop.Plants.Add(newPlant);
            //        //    await db.Plants.AddAsync(newPlant);
            //        //}

            //        //await db.SaveChangesAsync();

            //        return new ResponseVM() { Success = true, Msg = "Plants Added!" };
            //    }
            //    catch (Exception)
            //    {
            return new ResponseVM() { Msg = "Error adding plants..." };
            //    }
        }

        public async Task<ResponseVM> GetParentListAsync(int strainId)
        {
            //    try
            //    {
            //        //var mothers = await db.Plants.Where(p => p.SpeciesId == strainId).Select(p => new { p.Id, Name = p.Phase }).ToListAsync();
            //        //var mothers = await db.Plants.Where(p => p.IsMother && p.StrainId == strainId).Select(p => new { p.Id, Name = p.MotherName }).ToListAsync();
            //        //return new ResponseVM() { Success = true, Data = mothers };
            //    }
            //    catch (Exception)
            //    {
            return new ResponseVM() { Msg = "Error loading mothers" };
            //    }
        }
    }
}
