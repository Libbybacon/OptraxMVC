using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Models;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class GrowController(OptraxContext context) : TabsController(context)
    {
        [Authorize]
        public IActionResult Index()
        {
            TabsVM model = new()
            {
                Area = "Grow",
                Tabs = [new Tab("Locations", "./Locations/LoadLocations/"), new Tab("Plants", "./Plants/LoadPlants/")]
            };

            return View(model);
        }
    }
}
