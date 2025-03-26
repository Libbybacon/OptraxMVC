using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using System.Text.Json.Serialization;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class LocationsController(OptraxContext context, IOptionsService optionsService, ILocationService locationService) : BaseController(context)
    {
        private readonly ILocationService _ILocation = locationService;
        private readonly IOptionsService _IOptions = optionsService;

        [HttpGet]
        public IActionResult LoadLocations()
        {
            ViewData["LocTabs"] = new TabsVM()
            {
                Area = "",
                Tabs = [new Tab("Site Details"), new Tab("Inventory")]
            };

            SiteLocation? model = db.SiteLocations.Where(l => l.IsPrimary).FirstOrDefault();

            return PartialView("_Locations", model);
        }

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
                return Json(new { Success = false, Msg = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> LoadCreate(string type)
        {
            try
            {
                ViewBag.IsFirst = type == "firstSite";

                ViewBag.FormVM = new FormVM()
                {
                    IsNew = true,
                    Action = $"Create",
                    MsgDiv = "tableMsg"
                };

                LocationVM model = type switch
                {

                    "Site" => new LocationVM(new SiteLocation()),
                    "Field" => new LocationVM(new FieldLocation()),
                    "Row" => new LocationVM(new RowLocation()),
                    "Bed" => new LocationVM(new BedLocation()),
                    "Plot" => new LocationVM(new PlotLocation()),
                    "Greenhouse" => new LocationVM(new GreenhouseLocation()),
                    "Building" => new LocationVM(new BuildingLocation()),
                    "Room" => new LocationVM(new RoomLocation()),
                    "Offsite" => new LocationVM(new OffsiteLocation()),
                    _ => new LocationVM(new SiteLocation()),
                };

                ViewData["Dropdowns"] = await _IOptions.LoadOptions(["StateSelects"]);

                return PartialView("_Create", model);
            }
            catch (Exception ex)
            {
                return Json(new { Success = false, Msg = ex.Message });
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
                    //model.AvailableParents = [.. db.Locations
                    //    .Select(l => new SelectListItem
                    //    {
                    //        Value = l.ID.ToString(),
                    //        Text = l.Name
                    //    })];

                    return Json(new ResponseVM() { Msg = "Invalid model" });
                }

                Location loc = model.LocationType.ToLower() switch
                {
                    "vehicle" => new VehicleLocation(),
                    "site" => new SiteLocation(model.Address, model.Business),
                    "greenhouse" => new GreenhouseLocation(),
                    "field" => new FieldLocation(),
                    "row" => new RowLocation(),
                    "bed" => new BedLocation(),
                    "plot" => new PlotLocation(),
                    "building" => new BuildingLocation(),
                    "room" => new RoomLocation(),
                    "offsite" => new OffsiteLocation(),
                    _ => new SiteLocation()
                };

                loc.Name = model.Name;
                loc.Details = model.Details;
                loc.ParentID = model.ParentID;

                if (loc is SiteLocation site)
                {
                    site.BusinessID = model.BusinessID;
                    site.AddressID = model.AddressID;
                }

                //loc.Level = model.ParentID.HasValue
                //    ? db.Locations.Find(model.ParentID.Value)?.Level + 1 ?? 1
                //: 0;

                await db.Locations.AddAsync(loc);
                await db.SaveChangesAsync();

                return Json(new ResponseVM() { Success = true, Data = loc.ToTreeNode() });
            }
            catch (Exception ex)
            {
                return Json(new ResponseVM() { Msg = "Error creating location: " + ex.Message });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateBuildingAsync(BuildingLocation loc)
        {
            if (!ModelState.IsValid)
            {
                return Json(new ResponseVM() { Msg = "Invalid model" });
            }

            ResponseVM response = await CreateAsync(loc);
            return Json(response, ReferenceHandler.Preserve);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateRoomAsync(RoomLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { Msg = "Invalid model" });

            return Json(await CreateAsync(loc));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateVehicleAsync(VehicleLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { Msg = "Invalid model" });

            return Json(await CreateAsync(loc));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateOffsiteAsync(OffsiteLocation loc)
        {
            if (!ModelState.IsValid)
                return Json(new { Msg = "Invalid model" });

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
                return new ResponseVM { Success = false, Msg = "Error saving location..." };
            }
        }
    }
}
