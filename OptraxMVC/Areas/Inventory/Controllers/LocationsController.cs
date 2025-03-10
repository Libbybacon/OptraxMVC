using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Services.Inventory;
using OptraxMVC.Services;
using OptraxDAL.Models.Admin;
using OptraxDAL.Models.Inventory;
using OptraxMVC.Models;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    [Area("Inventory")]
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
        public IActionResult Create(string type)
        {
            try
            {
                ViewBag.FormVM = new FormVM()
                {
                    IsNew = true,
                    JsFunc = "addLocation",
                    Action = "Create",
                    MsgDiv = "tableMsg"
                };

                object? model;
                switch (type)
                {
                    case "Building":
                        ViewData["States"] = _IDropdowns.GetStatesList();
                        model = new BuildingLocation() {Address = new Address() { } };
                        break;
                    case "Room":
                        model = new RoomLocation() { };
                        break;
                    case "Container":
                        model = new ContainerLocation() { };
                        break;
                    case "Off-Site":
                        model = new OffsiteLocation() { };
                        break;

                }


                return PartialView("_Create");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, msg = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult LoadAddress()
        {
            try
            {
                string view = "~/Admin/Views/_Address.cshtml";
                ViewData["States"] = _IDropdowns.GetStatesList();
                Address address = new Address() { };

                return PartialView(view, address);
            }
            catch (Exception ex)
            {
                return Json(new { success = false });
            }
        }
    }
}
