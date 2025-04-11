using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxDAL.Models.Maps;
using OptraxMVC.Areas.Grow.Models;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;
using OptraxMVC.Services.Grow;

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
                    return Json(JsonVM("No map found"));
                }
                return Json(JsonVM(map));
            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error getting map: " + ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateMapAsync(Map map)
        {
            if (!ModelState.IsValid) { return Json(JsonVM("Invalid map")); }

            try
            {
                Map? savedMap = await _Map.CreateMapAsync(map);

                if (savedMap == null)
                {
                    return Json(JsonVM("Error creating map"));
                }

                return Json(JsonVM(savedMap));
            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error creating map: " + ex.Message));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditMapAsync(Map map)
        {
            if (!ModelState.IsValid) { return Json(JsonVM("Invalid map")); }

            try
            {
                string response = await _Map.EditMapAsync(map);

                if (response == "OK")
                {
                    return Json(JsonVM(true));
                }
                else
                {
                    return Json(JsonVM(response));
                }
            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error updating map: " + ex.Message));
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
                return Json(JsonVM("Error getting map objects"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> AddNewObject(string objType)
        {
            try
            {
                MapObject model = objType switch
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

                return PartialView("_MapObject", new MapObjectVM(model));
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> CreateAsync(MapObjectVM objVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(JsonVM("Invalid model state"));
                }

                MapObject obj = objVM.GetObject();

                string response = await _Map.CreateObjectAsync(obj);

                if (response == "OK")
                {
                    return Json(JsonVM(obj.ToGeoJSON()));
                }
                return Json(JsonVM(response));
            }
            catch (Exception)
            {
                return Json(JsonVM("Error creating point"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> LoadEdit(int? id, string objType)
        {
            if (id == null) { return Json(JsonVM("Invalid object Id")); }

            MapObject? model = await _Map.GetObjectAsync((int)id, objType);

            if (model == null) { return Json(JsonVM("Object not found")); }

            LoadFormVM(objType, "EditObject");

            ViewData["Options"] = await _Options.LoadOptions(["LocationSelects", "IconsList"]);

            return PartialView("_MapObject", new MapObjectVM(model));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> EditObjectAsync(MapObjectVM objVM)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Json(JsonVM("Invalid model state"));
                }

                MapObject? dbObj = await _Map.EditObjectAsync(objVM.GetObject());

                if (dbObj == null)
                {
                    return Json(JsonVM("Error editing object"));
                }

                return Json(JsonVM(dbObj.ToGeoJSON()));
            }
            catch (Exception)
            {
                return Json(JsonVM("Error creating point"));
            }
        }

        private void LoadFormVM(string type, string action)
        {
            ViewBag.FormVM = new FormVM(action, type);
            ViewBag.IconCollId = 1;
        }

        [HttpPost]
        public async Task<JsonResult> DeleteObject(int? id, string objType)
        {
            try
            {
                if (id == null)
                {
                    return Json(JsonVM("Null object id"));
                }

                return Json(await _Map.DeleteObjectAsync((int)id, objType));

            }
            catch (Exception ex)
            {
                return Json(JsonVM("Error deleting line: " + ex.Message));
            }
        }
    }
}
