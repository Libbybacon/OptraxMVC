using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Map;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class MapController(OptraxContext context, IDropdownService dropdownService, IMapService mapService) : BaseController(context)
    {
        private readonly IMapService _IMap = mapService;
        private readonly IDropdownService _IDropdowns = dropdownService;

        [HttpGet]
        public async Task<IActionResult> GetMapObjects()
        {
            try
            {
                return Json(await _IMap.GetMapObjectsAsync());
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error getting map objects" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddPoint(decimal? lat, decimal? lng)
        {
            if (lat == null || lng == null)
                return Json(new { msg = "Invalid coordinates" });

            ViewBag.IconCollID = 1;
            ViewBag.FormVM = LoadFormVM("Point");
            ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["LocationSelects", "IconsList"]);

            return PartialView("_Point", await _IMap.LoadNewPointAsync((decimal)lat, (decimal)lng));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreatePointAsync(MapPoint point)
        {
            try
            {
                if (!ModelState.IsValid)
                    return Json(new ResponseVM { msg = "Invalid model state" });

                return Json(await _IMap.CreatePointAsync(point));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating point" });
            }
        }

        private static FormVM LoadFormVM(string objType)
        {
            FormVM formVM = new()
            {
                IsNew = true,
                JsFunc = $"add{objType}",
                Action = $"Create{objType}",
                MsgDiv = "mapMsg"
            };
            return formVM;
        }
    }
}
