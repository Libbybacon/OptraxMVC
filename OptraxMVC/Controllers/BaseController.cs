﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using OptraxDAL;

namespace OptraxMVC.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly OptraxContext db;

        protected BaseController(OptraxContext context)
        {
            db = context;
        }

        public Dictionary<string, string> GetMenuItems()
        {
            return new Dictionary<string, string>() {
                { "Home", "grid-3x3" },
                { "Grow", "flower2" },
                { "Harvest", "scissors" },
                { "Inventory", "basket3" },
                { "Reports", "file-bar-graph" },
            };

        }

        //protected string RenderViewToString(string viewName, object model)
        //{
        //    ViewData.Model = model;
        //    using (var sw = new StringWriter())
        //    {
        //        var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext, viewName);
        //        var viewContext = new ViewContext(ControllerContext, viewResult.View, ViewData, TempData, sw);
        //        viewResult.View.Render(viewContext, sw);
        //        viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
        //        return sw.GetStringBuilder().ToString();
        //    }
        //}
    }
}
