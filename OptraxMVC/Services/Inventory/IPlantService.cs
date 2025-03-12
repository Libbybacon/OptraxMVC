using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;
using System.Security.Claims;
using System.Text.Json;

namespace OptraxMVC.Services.Inventory
{
    public interface IPlantService
    {
        Task<Plant> LoadNewPlant();
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
        public async Task<Plant> LoadNewPlant()
        {
            int inventoryID = await GetPlantInventoryIDAsync();


            Plant plant = new()
            {
                InventoryItemID = inventoryID,
                PlantEvents = [
                new PlantEvent() {
                        Date = DateTime.Now,
                        EventType = "Transfer",
                        Transfer = new InventoryTransfer() {
                            Date = DateTime.Now,
                        }
                    }]
            };

            return plant;
        }

        [Authorize]
        public async Task<int> GetPlantInventoryIDAsync()
        {
            return await db.InventoryItems.Where(i => i.Name == "Plant").Select(i => i.ID).FirstAsync();
        }

        [Authorize]
        public async Task<ResponseVM> CreateAsync(Plant plant, string userID)
        {
            var invItem = await db.InventoryItems.FindAsync(await GetPlantInventoryIDAsync());
            plant.InventoryItem = invItem;

            var strain = await db.Strains.FindAsync(plant.StrainID);

            if (strain == null)
                return new ResponseVM() { msg = "Could not find Strain" };

            try
            {
                Crop crop = plant.Crop ?? new Crop() { };
                plant.Crop = crop;
                crop.Strain = strain;
                plant.Strain = strain;

                if (plant.IsMother)
                {
                    Crop? dbCrop = await db.Crops.Where(c => c.BatchID == crop.BatchID).FirstOrDefaultAsync();

                    if (dbCrop != null)
                    {
                        plant.CropID = dbCrop.ID;
                        plant.Crop = dbCrop;
                        dbCrop.Plants.Add(plant);
                    }
                    else
                    {
                        crop.Plants.Add(plant);
                        await db.Crops.AddAsync(crop);
                    }
                    await db.Plants.AddAsync(plant);

                    //TransferEvent transfer = await CreateTransferEventAsync(plant);
                }
                else 
                {
                    for (int i = 0; i < plant.Quantity; i++)
                    {
                        var newPlant = plant.NewPlant();
                        crop.Plants.Add(newPlant);
                        await db.Plants.AddAsync(newPlant);
                    }

                    await db.Crops.AddAsync(crop);
                }


                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, msg = "Plants Added!"};
            }
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error adding plants..."};
            }
        }

        public async Task<ResponseVM> GetParentListAsync(int strainID)
        {
            try
            {
                var mothers = await db.Plants.Where(p => p.IsMother && p.StrainID == strainID).Select(p => new { p.ID, Name = p.MotherName }).ToListAsync();
                return new ResponseVM() { success = true, data = mothers };
            }
            catch (Exception)
            {
                return new ResponseVM() { msg = "Error loading mothers" };
            }
        }
        //private async Task<TransferEvent> CreateTransferEventAsync(Plant plant)
        //{

        //}
    }
}
