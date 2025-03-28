using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Maps;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    [Authorize]
    public class MapController(OptraxContext context, IOptionsService optionsService, IMapService mapService) : BaseController(context)
    {
        private readonly IMapService _Map = mapService;
        private readonly IOptionsService _Options = optionsService;

        [HttpGet]
        public async Task<JsonResult> GetMap()
        {
            try
            {
                Map? map = await _Map.GetMapAsync();
                if (map == null)
                {
                    return Json(ResponseVM("No map found"));
                }
                return Json(ResponseVM(map));
            }
            catch (Exception ex)
            {
                return Json(ResponseVM("Error getting map: " + ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateMapAsync(Map map)
        {
            if (!ModelState.IsValid) { return Json(ResponseVM("Invalid map")); }

            try
            {
                return Json(await _Map.CreateMapAsync(map));
            }
            catch (Exception ex)
            {
                return Json(ResponseVM("Error creating map: " + ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditMapAsync(Map map)
        {
            if (!ModelState.IsValid) { return Json(ResponseVM("Invalid map")); }

            try
            {
                return Json(await _Map.EditMapAsync(map));
            }
            catch (Exception ex)
            {
                return Json(ResponseVM("Error updating map: " + ex.Message));
            }
        }

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
                return Json(await _Map.GetObjectsAsync(objType));
            }
            catch (Exception)
            {
                return Json(ResponseVM("Error getting map objects"));
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
                    ViewData["Options"] = await _Options.LoadOptions(["IconsList"]);
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

            object? model = await _Map.GetObjectAsync((int)id, objType);

            if (model == null) { return Json(new ResponseVM() { Msg = "Object not found" }); }

            LoadFormVM(objType, "Edit");
            ViewData["Options"] = await _Options.LoadOptions(["LocationSelects", "IconsList"]);

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

                return Json(await _Map.DeleteObjectAsync((int)id, objType));

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

                return Json(await _Map.CreateObjectAsync(point));
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

                return Json(await _Map.EditObjectAsync(point));
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

                return Json(await _Map.CreateObjectAsync(line));
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

                return Json(await _Map.EditObjectAsync(line));
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

                return Json(await _Map.CreateObjectAsync(circle));
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

                return Json(await _Map.EditObjectAsync(circle));
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

                return Json(await _Map.CreateObjectAsync(poly));
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

                return Json(await _Map.EditObjectAsync(poly));
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
