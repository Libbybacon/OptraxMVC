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
        Task<Plant> LoadNewPlant(string UserID);
        Task<ResponseVM> GetParentListAsync(int strainID);
        Task<int> GetPlantInventoryIDAsync();
        Task<List<PlantVM>> GetPlantsAsync();
        Task<ResponseVM> CreateAsync(Plant plant, string userID);
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
        public async Task<Plant> LoadNewPlant(string UserID)
        {
            int inventoryID = await GetPlantInventoryIDAsync();

            var transfer = new InventoryTransfer()
            {
                Date = DateTime.Now,
                UserID = UserID,
                UnitCount = 1,
                UnitUoM = "Each",
                IsPartial = false,
                Status = "Initiated",
                NeedsApproval = false,
            };

            Plant plant = new()
            {
                PurchaseDate = DateTime.Now,
                ResourceID = inventoryID,
                PlantEvents = [
                new TransferEvent() {
                        Date = DateTime.Now,
                        EventType = "Transfer",
                        UserID = UserID,
                        Transfer = transfer
                    }]
            };

            return plant;
        }

        [Authorize]
        public async Task<int> GetPlantInventoryIDAsync()
        {
            return await db.Resources.Where(i => i.Name == "Plant").Select(i => i.ID).FirstAsync();
        }

        [Authorize]
        public async Task<ResponseVM> CreateAsync(Plant plant, string userID)
        {
            plant.Resource = await db.Resources.FindAsync(await GetPlantInventoryIDAsync());

            var strain = await db.Strains.FindAsync(plant.SpeciesID);

            if (strain == null)
                return new ResponseVM() { Msg = "Could not find Strain" };

            try
            {
                //Crop crop = await db.Crops.Where(c => c.BatchID == plant.Crop.BatchID).FirstOrDefaultAsync() ?? plant.Crop;

                //if (crop.StrainID != plant.SpeciesID)
                //    return new ResponseVM() { Msg = "Plant Strain does not match Crop Strain" };

                //plant.Crop = crop;
                ////crop.Strain = strain;
                ////plant.Strain = strain;

                //var mapper = new MapperConfiguration(cfg => cfg.AddProfile<PlantProfile>()).CreateMapper();

                //for (int i = 0; i < plant.Quantity; i++)
                //{
                //    var newPlant = mapper.Map<Plant>(plant);
                //    crop.Plants.Add(newPlant);
                //    await db.Plants.AddAsync(newPlant);
                //}

                //await db.SaveChangesAsync();

                return new ResponseVM() { Success = true, Msg = "Plants Added!" };
            }
            catch (Exception)
            {
                return new ResponseVM() { Msg = "Error adding plants..." };
            }
        }

        public async Task<ResponseVM> GetParentListAsync(int strainID)
        {
            try
            {
                var mothers = await db.Plants.Where(p => p.SpeciesID == strainID).Select(p => new { p.ID, Name = p.Phase }).ToListAsync();
                //var mothers = await db.Plants.Where(p => p.IsMother && p.StrainID == strainID).Select(p => new { p.ID, Name = p.MotherName }).ToListAsync();
                return new ResponseVM() { Success = true, Data = mothers };
            }
            catch (Exception)
            {
                return new ResponseVM() { Msg = "Error loading mothers" };
            }
        }
    }
}
