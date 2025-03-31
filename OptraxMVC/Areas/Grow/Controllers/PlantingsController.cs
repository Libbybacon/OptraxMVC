using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class PlantingsController(OptraxContext context, IMapService mapService, IOptionsService optionsService) : BaseController(context)
    {
        private readonly IMapService _Map = mapService;
        private readonly IOptionsService _Options = optionsService;

        public IActionResult GetPlantings()
        {
            return PartialView("_Plantings");
        }
    }
}
