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
        public async Task<IActionResult> AddPoint(decimal? lat, decimal? lng)
        {
            if (lat == null || lng == null)
                return Json(new { msg = "Invalid coordinates" });

            ViewBag.FormVM = LoadFormVM("Point");
            ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["LocationSelects", "IconsList"]);

            return PartialView("_Point", await _IMap.LoadNewPointAsync((decimal)lat, (decimal)lng));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPointAsync(MapPoint point)
        {
            if (!ModelState.IsValid)
                return Json(new { msg = "Invalid model state" });

            return Json(await _IMap.AddPoint(point));
        }

        private static FormVM LoadFormVM(string objType)
        {
            FormVM formVM = new()
            {
                IsNew = true,
                JsFunc = $"add{objType}",
                Action = $"Add{objType}",
                MsgDiv = "mapMsg"
            };
            return formVM;
        }
    }
}
