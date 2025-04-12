using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Controllers;
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
                return Json(JsonVM(ex.Message));
            }
        }

        [HttpGet]
        public IActionResult LoadCreate(string type, string? parentId)
        {
            try
            {
                int? parId = int.TryParse(parentId, out int id) ? id : null;
                LocationVM model = new(type, parId);

                return GetLocationView(model, "Create");
            }
            catch (Exception ex)
            {
                return Json(JsonVM(ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAsync(LocationVM model)
        {
            try
            {
                if (!ModelState.IsValid) { return Json(JsonVM("Invalid model")); }

                Location? savedLoc = await _Location.CreateAsync(model.Location);

                if (savedLoc == null) { return Json(JsonVM("Error creating location")); }

                return Json(JsonVM(savedLoc.ToTreeNode()));
            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error creating location: " + ex.Message));
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int? id, string? type)
        {
            try
            {
                if (id == null || type == null) { return Json(JsonVM("Error loading location - null id or type")); }

                Location? model = await _Location.GetLocationAsync((int)id, type);

                if (model == null) { return Json(JsonVM("Error loading location: not found")); }

                return GetLocationView(new LocationVM(model), "Edit");
            }
            catch (Exception ex)
            {
                return Json(JsonVM(ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditAsync(LocationVM locVM)
        {
            if (!ModelState.IsValid) { return Json(JsonVM("Invalid model")); }

            try
            {
                Location? loc = locVM.GetLocation();

                if (loc == null) { return Json(JsonVM("No Location")); }

                string response = await _Location.EditAsync(loc);
                if (response == "OK")
                {
                    return Json(JsonVM(true));
                }
                return Json(JsonVM(response));
            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error deleting location - " + ex.Message));
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteAsync(int? id)
        {
            try
            {
                if (id == null) { return Json(JsonVM("Error deleting location - null Id")); }

                return Json(await _Location.DeleteAsync((int)id));
            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error deleting location - " + ex.Message));
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
                return Json(JsonVM(ex.Message));
            }
        }
    }
}
