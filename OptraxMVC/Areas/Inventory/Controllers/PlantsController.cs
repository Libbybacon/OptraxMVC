using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Grow;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
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

                ViewData["StrainsList"] = _IDropdowns.GetStrains();
                ViewData["Phases"] = _IDropdowns.GetGrowthPhasesList();
                ViewData["StartTypes"] = _IDropdowns.GetStartTypesList();

                int inventoryID = await _IPlants.GetPlantInventoryIDAsync();

                return PartialView("_Create", new Plant() { InventoryItemID = inventoryID, });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Plant plant)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model" });

            try
            {
                ResponseVM response = await _IPlants.CreateAsync(plant);

                return Json(response);
            }
            catch (Exception ex) {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}

