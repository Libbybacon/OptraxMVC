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
                Tabs = [new Tab("Map"), new Tab("Locations"), new Tab("Plants")]
            };

            return View(model);
        }
    }
}
