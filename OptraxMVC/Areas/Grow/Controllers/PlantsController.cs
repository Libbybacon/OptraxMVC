using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class PlantsController(OptraxContext context, IDropdownService dropdownService, IPlantService plantService) : BaseController(context)
    {
        private readonly IPlantService _IPlants = plantService;
        private readonly IDropdownService _IDropdowns = dropdownService;

        [HttpGet]
        public async Task<IActionResult> GetPlants()
        {
            try
            {
                var data = await _IPlants.GetPlantsAsync();

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.FormVM = new FormVM()
                {
                    IsNew = true,
                    JsFunc = "addPlants",
                    Action = "Create",
                    MsgDiv = "tableMsg"
                };

                ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["StrainSelects", "PhaseSelects", "OriginTypeSelects", "LocationSelects", "UomSelects"]);

                Plant plant = await _IPlants.LoadNewPlant(UserID);

                return PartialView("_Create", plant);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(Plant plant)
        {
            if (plant.PlantEvents.First() is TransferEvent transferEvent)
            {
                TryValidateModel(transferEvent.Transfer, "PlantEvents[0].Transfer");
            }
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model" });

            try
            {
                ResponseVM response = await _IPlants.CreateAsync(plant, UserID);

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetParentList(int strainID)
        {
            try
            {
                ResponseVM response = await _IPlants.GetParentListAsync(strainID);

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}

