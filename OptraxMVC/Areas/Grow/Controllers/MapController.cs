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
        public async Task<JsonResult> GetPointsAsync()
        {
            try
            {
                return Json(await _IMap.GetPointsAsync());
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
            {
                return Json(new { msg = "Invalid coordinates" });
            }

            LoadFormVM("Point", "Create");

            return PartialView("_Point", await _IMap.LoadNewPointAsync((decimal)lat, (decimal)lng));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreatePointAsync(MapPoint point)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM { msg = "Invalid model state" });
                }

                return Json(await _IMap.CreatePointAsync(point));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating point" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditPoint(int? pointID)
        {
            try
            {
                if (pointID == null)
                {
                    return Json(new { msg = "Invalid point ID" });
                }

                MapPoint? point = await _IMap.LoadEditPointAsync((int)pointID);

                if (point == null)
                {
                    return Json(new ResponseVM { msg = "No point found" });
                }

                LoadFormVM("Point", "Edit");

                return PartialView("_Point", point);
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error loading point" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditPointAsync(MapPoint point)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM { msg = "Invalid model state" });
                }

                return Json(await _IMap.EditPointAsync(point));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating point" });
            }
        }

        [HttpGet]
        public IActionResult AddLine(string? lineString)
        {
            if (string.IsNullOrEmpty(lineString))
            {
                return Json(new { msg = "Invalid coordinates" });
            }

            LoadFormVM("Line", "Create");

            return PartialView("_Line", new MapLine() { LineString = lineString });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateLineAsync(MapLine line)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM { msg = "Invalid model state" });
                }

                return Json(await _IMap.CreateLineAsync(line));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating line" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditLine(int? lineID)
        {
            try
            {
                if (lineID == null)
                {
                    return Json(new { msg = "Invalid line ID" });
                }

                MapLine? line = await _IMap.LoadEditLineAsync((int)lineID);

                if (line == null)
                {
                    return Json(new ResponseVM { msg = "No line found" });
                }

                LoadFormVM("Line", "Edit");

                return PartialView("_Line", line);
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error loading line" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditLineAsync(MapLine line)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM { msg = "Invalid model state" });
                }

                return Json(await _IMap.EditLineAsync(line));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating line" });
            }
        }


        private void LoadFormVM(string objType, string funcType)
        {
            ViewBag.FormVM = new FormVM()
            {
                IsNew = funcType == ("Create"),
                JsFunc = $"{funcType.ToLower()}{objType}",
                Action = $"{funcType}{objType}",
                MsgDiv = "mapMsg"
            };

            ViewBag.IconCollID = 1;

            ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["LocationSelects", "IconsList"]);
        }
    }
}
