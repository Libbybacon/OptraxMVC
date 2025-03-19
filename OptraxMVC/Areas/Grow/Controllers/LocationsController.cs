using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Inventory;
using System.Text.Json.Serialization;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class LocationsController(OptraxContext context, IDropdownService dropdownService, ILocationService locationService) : BaseController(context)
    {
        private readonly ILocationService _ILocation = locationService;
        private readonly IDropdownService _IDropdowns = dropdownService;

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> GetLocations()
        {
            try
            {
                var data = await _ILocation.GetLocationsAsync();

                return Json(data);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult LoadCreate(string type)
        {
            try
            {
                ViewBag.FormVM = new FormVM()
                {
                    IsNew = true,
                    JsFunc = "addLocation",
                    Action = $"Create{type}",
                    MsgDiv = "tableMsg"
                };

                object? model = null;
                switch (type)
                {
                    case "Building":
                        ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["StateSelects"]);
                        model = new BuildingLocation() { LocationType = type, Address = new Address() { } };
                        break;
                    case "Room":
                        ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["BuildingSelects"]);
                        model = new RoomLocation() { LocationType = type };
                        break;
                    case "Vehicle":
                        model = new VehicleLocation() { LocationType = type };
                        break;
                    case "OffSite":
                        model = new OffsiteLocation() { LocationType = type };
                        break;
                }
                return PartialView("_Create", model);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBuildingAsync(BuildingLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model" });
            ResponseVM response = await CreateAsync(loc);
            return Json(response, ReferenceHandler.Preserve);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRoomAsync(RoomLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model" });

            return Json(await CreateAsync(loc));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVehicleAsync(VehicleLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model" });

            return Json(await CreateAsync(loc));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOffsiteAsync(OffsiteLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model" });

            return Json(await CreateAsync(loc));
        }

        private async Task<ResponseVM> CreateAsync(Location loc)
        {
            try
            {
                ResponseVM response = await _ILocation.CreateAsync(loc);
                return response;
            }
            catch (Exception)
            {
                return new ResponseVM { success = false, msg = "Error saving location..." };
            }
        }
    }
}
