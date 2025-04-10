using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Models;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class GrowController(OptraxContext context) : BaseController(context)
    {
        [Authorize]
        public IActionResult Index()
        {
            List<Tab> model = [
                new Tab("Locations", "./Locations/LoadLocations/"),
                new Tab("Plants", "./Plants/LoadPlants/")
            ];

            return View(model);
        }
    }
}
