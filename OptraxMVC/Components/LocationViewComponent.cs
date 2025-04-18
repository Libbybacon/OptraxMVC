﻿using Microsoft.AspNetCore.Mvc;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models.ViewModels;
using OptraxMVC.Services;


namespace OptraxMVC.Components
{
    public class LocationViewComponent(IOptionsService options) : ViewComponent
    {
        private readonly IOptionsService _Options = options;

        public IViewComponentResult Invoke(Location location, OptionsVM optionsVM)
        {
            ViewData["Options"] = optionsVM;
            return View(location);
        }
    }
}
