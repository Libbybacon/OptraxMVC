using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class LocationsController(OptraxContext context, IOptionsService optionsService, ILocationService locationService) : BaseController(context)
    {
        private readonly ILocationService _Location = locationService;
        private readonly IOptionsService _Options = optionsService;


        [HttpGet]
        public async Task<IActionResult> LoadLocations()
        {
            SiteLocation? loc = db.SiteLocations.Where(l => l.IsPrimary).FirstOrDefault();

            LocationVM model = loc != null ? new(loc) : new LocationVM().LoadVM("firstSite");

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
                var data = await _Location.GetLocationsAsync();

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }


        private async Task<IActionResult> GetLocationView(LocationVM model, string action)
        {
            try
            {
                ViewBag.Action = action;
                ViewBag.ShowEdit = action != "Details";
                ViewData["Options"] = await _Options.LoadOptions(["StateSelects", "LocTypeSelects", "LocSelectsByLevel"], model.Level);

                return PartialView("_Location", model);
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
            }
        }


        [HttpGet]
        public async Task<IActionResult> LoadCreate(string type)
        {
            try
            {
                LocationVM model = new LocationVM().LoadVM(type);

                return await GetLocationView(model, "Create");
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
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

                return await GetLocationView(model, "Details");
            }
            catch (Exception ex)
            {
                return Json(ResponseVM(ex.Message));
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
    }
}
