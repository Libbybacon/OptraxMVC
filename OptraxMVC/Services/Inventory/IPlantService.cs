using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Models;
using System.Text.Json;

namespace OptraxMVC.Services.Inventory
{
    public interface IPlantService
    {
        Task<int> GetPlantInventoryIDAsync();
        Task<List<PlantVM>> GetPlantsAsync();
        Task<ResponseVM> CreateAsync(Plant plant);
    }

    public class PlantService(OptraxContext context) : IPlantService
    {
        private readonly OptraxContext db = context;

        public async Task<List<PlantVM>> GetPlantsAsync()
        {
            return await db.Database.SqlQuery<PlantVM>($"GetPlantsTableData").ToListAsync();
        }

        public async Task<int> GetPlantInventoryIDAsync()
        {
            return await db.InventoryItems.Where(i => i.Name == "Plant").Select(i => i.ID).FirstAsync();
        }

        public async Task<ResponseVM> CreateAsync(Plant plant)
        {
            var invItem = await db.InventoryItems.FindAsync(await GetPlantInventoryIDAsync());
            plant.InventoryItem = invItem;

            var strain = await db.Strains.FindAsync(plant.StrainID);

            if (strain == null)
                return new ResponseVM() { msg = "Could not find Strain" };

            plant.Strain = strain;

            List<Plant> newPlants = [];
            for (int i = 0; i < plant.Quantity; i++)
            {
                var newPlant = plant.NewPlant();
                newPlants.Add(newPlant);
            }

            try
            {
                Crop crop = plant.Crop ?? new Crop() { };
                Crop? dbCrop = null;
                var mother = newPlants[0];
                if (plant.IsMother)
                {                   
                    dbCrop = await db.Crops.Where(c => c.BatchID == crop.Name).FirstOrDefaultAsync();

                    if (dbCrop != null)
                    {
                        mother.Crop = dbCrop;
                        mother.CropID = dbCrop.ID;
                    }
                    else
                    {
                        crop.Strain = strain;
                        await db.Crops.AddAsync(crop);
                        mother.Crop = crop;
                        
                    }
                    await db.Plants.AddAsync(mother);
                }
                else /*(dbCrop == null)*/
                {
                    crop.Strain = strain;
                    crop.Plants = [];

                    await db.Crops.AddAsync(crop);

                    newPlants.ForEach(p => { p.Crop = crop; crop.Plants.Add(p); db.Plants.Add(p); });
                }
            }
            catch
            {
                return new ResponseVM() { msg = "Error saving Crop" };
            }

            try
            {
                await db.SaveChangesAsync();

                return new ResponseVM() { success = true, msg = "Plants Added!"};
            }
            catch (Exception ex)
            {
                return new ResponseVM() { msg = "Error adding plants: " + ex };
            }
        }

        public async Task<List<Plant>> SavePlantsAsync(Plant plant)
        {
            try
            {
                List<Plant> plants = [];

                for (int i = 0; i < plant.Quantity; i++)
                {
                    var newPlant = plant;
                    await db.Plants.AddAsync(newPlant);
                    plants.Add(newPlant);
                }
                return plants;
            }
            catch (Exception)
            {
                return [];
            }
        }
        public async Task<Crop?> SaveCropAsync(Crop crop)
        {
            try
            {
                await db.AddAsync(crop);
                await db.SaveChangesAsync();

                return crop;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
