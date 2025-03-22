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
        public async Task<JsonResult> GetObjectsAsync(string objType)
        {
            try
            {

                return Json(await _IMap.GetObjectsAsync(objType));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error getting map objects" });
            }
        }

        [HttpGet]
        public IActionResult AddNewObject(string objType)
        {
            try
            {
                object model = objType switch
                {
                    "point" => new MapPoint(),
                    "line" => new MapLine(),
                    "circle" => new MapCircle(),
                    _ => new MapPolygon(),
                };
                string view = objType switch
                {
                    "point" => "Point",
                    "line" => "Line",
                    "circle" => "Circle",
                    _ => "Polygon"
                };

                LoadFormVM(view, "Create");

                return PartialView($"_{view}", model);
            }
            catch (Exception)
            {
                return Json(new { success = false });
            }

        }

        [HttpGet]
        public async Task<IActionResult> LoadEdit(int? id, string objType)
        {
            if (id == null) { return Json(new { msg = "Invalid object ID" }); }

            object?[] data = await _IMap.GetObjectAsync((int)id, objType);

            if (data == null || data.Length != 2 || data[1] == null) { return Json(new ResponseVM { msg = "Object not found" }); }

            LoadFormVM((string)data[0]!, "Edit");

            return PartialView("_Point", data[1]);
        }

        [HttpPost]
        public async Task<JsonResult> DeleteObject(int? id, string objType)
        {
            try
            {
                if (id == null)
                {
                    return Json(new ResponseVM { msg = "Null object id" });
                }


                return Json(await _IMap.DeleteObjectAsync((int)id, objType));

            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error deleting line" });
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
                    return Json(new ResponseVM { msg = "Invalid model state" });
                }

                return Json(await _IMap.CreateObjectAsync(point));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating point" });
            }
        }



        //[HttpGet]
        //public async Task<IActionResult> EditPoint(int? pointID)
        //{
        //    try
        //    {
        //        if (pointID == null)
        //        {
        //            return Json(new { msg = "Invalid point ID" });
        //        }

        //        MapPoint? point = await _IMap.LoadEditPointAsync((int)pointID);

        //        if (point == null)
        //        {
        //            return Json(new ResponseVM { msg = "No point found" });
        //        }

        //        LoadFormVM("Point", "Edit");

        //        return PartialView("_Point", point);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new ResponseVM { msg = "Error loading point" });
        //    }
        //}

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

                return Json(await _IMap.CreateObjectAsync(line));
            }
            catch (Exception)
            {
                return Json(new ResponseVM { msg = "Error creating line" });
            }
        }

        //[HttpGet]
        //public async Task<IActionResult> EditLine(int? lineID)
        //{
        //    try
        //    {
        //        if (lineID == null)
        //        {
        //            return Json(new { msg = "Invalid line ID" });
        //        }

        //        MapLine? line = await _IMap.LoadEditLineAsync((int)lineID);

        //        if (line == null)
        //        {
        //            return Json(new ResponseVM { msg = "No line found" });
        //        }

        //        LoadFormVM("Line", "Edit");

        //        return PartialView("_Line", line);
        //    }
        //    catch (Exception)
        //    {
        //        return Json(new ResponseVM { msg = "Error loading line" });
        //    }
        //}

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
            };

            ViewBag.IconCollID = 1;

            ViewData["Dropdowns"] = _IDropdowns.LoadDropdowns(["LocationSelects", "IconsList"]);
        }
    }
}
