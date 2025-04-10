using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Grow;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class LocationsController(OptraxContext context, ILocationService locationService, IMapService mapService, IOptionsService optionsService) : BaseController(context)
    {
        private readonly IMapService _Map = mapService;
        private readonly ILocationService _Location = locationService;
        private readonly IOptionsService _Options = optionsService;


        [HttpGet]
        public async Task<IActionResult> LoadLocations()
        {
            Site loc = await _Location.GetSiteLocationAsync() ?? new Site() { IsFirst = true, IsPrimary = true };

            LocationVM model = new(loc)
            {
                ShowEdit = loc.IsFirst,
                Map = await _Map.GetMapAsync() ?? new("Default Map"),
            };

            ViewBag.ShowEdit = loc.IsFirst;
            ViewBag.Action = loc.IsFirst ? "Create" : "Edit";

            return PartialView("_Locations", model);
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> GetLocationTreeData()
        {
            try
            {
                return Json(await _Location.GetTreeNodesAsync());
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }

        [HttpGet]
        public IActionResult LoadCreate(string type, string? parentId)
        {
            try
            {
                int? parId = int.TryParse(parentId, out int id) ? id : null;
                LocationVM model = new(type, parId);

                string action = type == "site" ? "CreateSite" : "CreateAreaLoc";
                return GetLocationView(model, "Create");
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(LocationVM model)
        {
            try
            {
                if (!ModelState.IsValid) { return Json(ResponseVM("Invalid model")); }

                return Json(await _Location.CreateAsync(model.Location));
            }
            catch (Exception ex)
            {
                return Json(new ResponseVM() { Msg = "Error creating location: " + ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSiteAsync(Site model)
        {
            try
            {
                if (!ModelState.IsValid) { return Json(ResponseVM("Invalid model")); }

                return Json(await _Location.CreateAsync(model));
            }
            catch (Exception ex)
            {
                return Json(new ResponseVM() { Msg = "Error creating location: " + ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAreaLocAsync(AreaLocation model)
        {
            try
            {
                if (!ModelState.IsValid) { return Json(ResponseVM("Invalid model")); }

                return Json(await _Location.CreateAsync(model));
            }
            catch (Exception ex)
            {
                return Json(new ResponseVM() { Msg = "Error creating location: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int? id, string? type)
        {
            try
            {
                if (id == null || type == null) { return Json(ResponseVM("Error loading location - null id or type")); }

                LocationVM? model = await _Location.GetLocationAsync((int)id, type);

                if (model == null) { return Json(ResponseVM("Error loading location: not found")); }

                string action = type == "site" ? "CreateSite" : "CreateAreaLoc";
                return GetLocationView(model, "Edit");
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(LocationVM locVM)
        {
            if (!ModelState.IsValid) { return Json(ResponseVM("Invalid model")); }

            try
            {
                return Json(await _Location.EditAsync(locVM.Location));
            }
            catch (Exception ex)
            {
                return Json(ResponseVM("Error deleting location - " + ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            try
            {
                if (id == null) { return Json(ResponseVM("Error deleting location - null Id")); }

                return Json(await _Location.DeleteAsync((int)id));
            }
            catch (Exception ex)
            {
                return Json(ResponseVM("Error deleting location - " + ex.Message));
            }
        }

        private IActionResult GetLocationView(LocationVM model, string action)
        {
            try
            {
                ViewBag.Action = action;
                ViewData["IsView"] = true;
                ViewBag.ShowEdit = action.Contains("Create");

                return PartialView("_Location", model);
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }
    }
}
