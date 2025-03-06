using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OptraxDAL;
using OptraxDAL.Models.Inventory;
using OptraxDAL.ViewModels;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
    public class PlantsController(OptraxContext context, IDropdownService dropdownService, IPlantService plantService) : BaseController(context, dropdownService)
    {
        private readonly IPlantService _IPlants = plantService;

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
        public IActionResult Create()
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

                ViewData["StrainsList"] = _IDropdowns.GetStrainsList();
                ViewData["Phases"] = _IDropdowns.GetGrowthPhasesList();
                ViewData["StartTypes"] = _IDropdowns.GetStartTypesList();
               
                return PartialView("_Create", new Plant() { });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }
    }
}
