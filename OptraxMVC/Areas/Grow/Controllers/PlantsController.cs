using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Grow;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Grow;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class PlantsController(OptraxContext context, IOptionsService optionsService, IPlantService plantService) : BaseController(context)
    {
        private readonly IPlantService _IPlants = plantService;
        private readonly IOptionsService _IOptions = optionsService;

        [HttpGet]
        public IActionResult LoadPlants()
        {
            return PartialView("_Plants");
        }

        [HttpGet]
        public async Task<IActionResult> GetPlantNodes(string? comName = null)
        {
            try
            {
                return Json(await _IPlants.GetPlantNodesAsync(comName));
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> LoadCreate(string type, string parentId)
        {
            try
            {
                if (type.Equals("species group", StringComparison.CurrentCultureIgnoreCase))
                {
                    return PartialView("_CreateGroup", new PlantTypeGroup() { PlantType = parentId });
                }

                Plant model = await _IPlants.LoadCreate(type, parentId);

                return await GetPlantView(model, "Create");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateGroupAsync(PlantTypeGroup group)
        {
            if (!ModelState.IsValid) { return Json(JsonVM("Invalid model")); }

            try
            {
                JsonVM response = await _IPlants.CreateGroupAsync(group);

                return Json(response);
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
            if (!ModelState.IsValid) { return Json(JsonVM("Invalid model")); }

            try
            {
                JsonVM response = await _IPlants.CreateAsync(plant, UserId);

                return Json(response);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        private async Task<IActionResult> GetPlantView(Plant model, string action)
        {
            try
            {
                ViewBag.Action = action;
                ViewData["IsView"] = true;
                ViewBag.ShowEdit = action.Contains("Create");
                ViewData["Options"] = await _IOptions.LoadOptions(["PlantTypeSelects", "TaxonSelects", "PlantSelects", "UomSelects"]);

                return PartialView("_Plant", model);
            }
            catch (Exception ex)
            {
                return Json(JsonVM(ex.Message));
            }
        }
    }
}

