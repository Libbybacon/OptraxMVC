using Microsoft.AspNetCore.Mvc;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models;
using OptraxMVC.Services;


namespace OptraxMVC.Components
{
    public class LocationViewComponent(IOptionsService options) : ViewComponent
    {
        private readonly IOptionsService _Options = options;

        public IViewComponentResult Invoke(Location location, OptionsVM dropdowns)
        {
            ViewData["Dropdowns"] = dropdowns;
            return View(location);
        }
    }
}
