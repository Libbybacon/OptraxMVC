using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Maps;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

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
            SiteLocation? loc = await _Location.GetSiteLocationAsync();
            Map? map = await _Map.GetMapAsync() ?? new("Default Map");

            LocationVM model = loc != null ? new(loc) : new LocationVM().LoadVM("firstSite");
            model.Map = map;

            ViewData["LocTabs"] = new TabsVM()
            {
                Area = "",
                Tabs = [
                    new Tab("Details", "./Locations/GetLocation/", true) { ID = model.ID},
                    new Tab("Actions") { ID = model.ID },
                    new Tab("Inventory")
                ]
            };
            ViewData["Options"] = await _Options.LoadOptions(["StateSelects"]);

            ViewBag.ShowEdit = model.IsFirstSite;
            ViewBag.Action = model.IsFirstSite ? "Create" : "Edit";

            return PartialView("_Locations", model);
        }


        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> GetLocationTreeData()
        {
            try
            {
                var data = await _Location.GetTreeNodesAsync();

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }


        [HttpGet]
        public async Task<IActionResult> LoadCreate(string type, string? parentID)
        {
            try
            {
                LocationVM? model = _Location.LoadCreate(type, parentID);

                if (model == null)
                {
                    return Json(ResponseVM("Error loading new " + type));
                }
                if (model.HasAddress)
                {
                    ViewData["Options"] = _Options.LoadOptions(["StateSelects",]);
                }

                return await GetLocationView(model, "Create");
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
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model" });
                }

                return Json(await _Location.CreateAsync(model));
            }
            catch (Exception ex)
            {
                return Json(new ResponseVM() { Msg = "Error creating location: " + ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetDetails(int? id)
        {
            try
            {
                if (id == null)
                {
                    return Json(ResponseVM("Error loading location - null ID"));
                }

                LocationVM? model = await _Location.GetLocationAsync((int)id);

                if (model == null)
                    return Json(ResponseVM("Error loading location: not found"));

                return await GetLocationView(model, "Edit");
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
            if (!ModelState.IsValid)
            {
                return Json(ResponseVM("Error editing location - invalid model"));
            }
            try
            {
                return Json(await _Location.EditAsync(locVM));
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
                if (id == null)
                {
                    return Json(ResponseVM("Error deleting location - null ID"));
                }

                return Json(await _Location.DeleteAsync((int)id));
            }
            catch (Exception ex)
            {
                return Json(ResponseVM("Error deleting location - " + ex.Message));
            }
        }



        private async Task<IActionResult> GetLocationView(LocationVM model, string action)
        {
            try
            {
                ViewBag.Action = action;
                ViewBag.ShowEdit = action == "Create";

                ViewData["Options"] = await _Options.LoadOptions(["StateSelects"]);

                return PartialView("_Location", model);
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }
    }
}
