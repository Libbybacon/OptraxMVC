using Microsoft.AspNetCore.Mvc;
using OptraxDAL.Models.Admin;
using OptraxMVC.Models;


namespace OptraxMVC.Components
{
    public class LocationViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(Location location, OptionsVM dropdowns)
        {
            ViewData["Dropdowns"] = dropdowns;
            return View(location);
        }
    }
}
