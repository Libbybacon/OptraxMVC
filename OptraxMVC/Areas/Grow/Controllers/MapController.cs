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
    public class MapController(OptraxContext context, IOptionsService optionsService, IMapService mapService) : BaseController(context)
    {
        private readonly IMapService _IMap = mapService;
        private readonly IOptionsService _IOptions = optionsService;

        [HttpGet]
        public IActionResult LoadMap()
        {
            return PartialView("_Map");
        }

        [HttpGet]
        public async Task<JsonResult> GetObjectsAsync(string objType)
        {
            try
            {
                return Json(await _IMap.GetObjectsAsync(objType));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error getting map objects" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddNewObject(string objType)
        {
            try
            {
                object model = objType switch
                {
                    "Point" => new MapPoint(),
                    "Line" => new MapLine(),
                    "Circle" => new MapCircle(),
                    _ => new MapPolygon(),
                };

                LoadFormVM(objType, "Create");

                if (model is MapPoint point)
                {
                    ViewData["Options"] = await _IOptions.LoadOptions(["IconsList"]);
                }

                return PartialView($"_{objType}", model);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpGet]
        public async Task<IActionResult> LoadEdit(int? id, string objType)
        {
            if (id == null) { return Json(new { Msg = "Invalid object ID" }); }

            object? model = await _IMap.GetObjectAsync((int)id, objType);

            if (model == null) { return Json(new ResponseVM() { Msg = "Object not found" }); }

            LoadFormVM(objType, "Edit");
            ViewData["Dropdowns"] = await _IOptions.LoadOptions(["LocationSelects", "IconsList"]);

            return PartialView($"_{objType}", model);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteObject(int? id, string objType)
        {
            try
            {
                if (id == null)
                {
                    return Json(new ResponseVM() { Msg = "Null object id" });
                }

                return Json(await _IMap.DeleteObjectAsync((int)id, objType));

            }
            catch (Exception ex)
            {
                return Json(new ResponseVM() { Msg = "Error deleting line: " + ex.Message });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreatePointAsync(MapPoint point)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.CreateObjectAsync(point));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating point" });
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
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.EditObjectAsync(point));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating point" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateLineAsync(MapLine line)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.CreateObjectAsync(line));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating line" });
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
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.EditObjectAsync(line));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error editing line" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateCircleAsync(MapCircle circle)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.CreateObjectAsync(circle));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating circle" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditCircleAsync(MapCircle circle)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.EditObjectAsync(circle));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating line" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreatePolygonAsync(MapPolygon poly)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.CreateObjectAsync(poly));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating line" });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditPolygonAsync(MapPolygon poly)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(new ResponseVM() { Msg = "Invalid model state" });
                }

                return Json(await _IMap.EditObjectAsync(poly));
            }
            catch (Exception)
            {
                return Json(new ResponseVM() { Msg = "Error creating line" });
            }
        }

        private void LoadFormVM(string objType, string funcType)
        {
            ViewBag.FormVM = new FormVM()
            {
                IsNew = funcType == ("Create"),
                JsFunc = $"{funcType.ToLower()}{objType}",
                Action = $"{funcType}{objType}",
                Type = objType
            };

            ViewBag.IconCollID = 1;
        }
    }
}
