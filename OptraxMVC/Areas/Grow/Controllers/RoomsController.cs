﻿using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class RoomsController(OptraxContext context) : BaseController(context)
    {
        public IActionResult Index()
        {
            //var rooms = db.Rooms.ToList();

            //return PartialView("_Rooms", rooms);
            return View();
        }
    }
}
