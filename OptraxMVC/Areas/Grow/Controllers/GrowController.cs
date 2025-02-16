using OptraxMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using OptraxMVC.Models;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class GrowController(OptraxContext context) : BaseController(context)
    {
        [Authorize]
        public IActionResult Index()
        {
            TabsVM tabs = new()
            {
                Area = "Grow",               
                Tabs =
                [
                    new Tab() { Name = "Rooms", ShortName = "room", ViewPath = "Rooms" },
                    new Tab() { Name = "Crops", ShortName = "crop", ViewPath = "Crop" },
                    new Tab() { Name = "Plants", ShortName = "plant", ViewPath = "Plant" },
                    new Tab() { Name = "Strains", ShortName = "strain", ViewPath = "Strain" },
                ]
            };

            return View("Tabs", tabs);
        }

        public async Task<IActionResult> LoadTabContent(Tab tab)
        {
            object? model = tab.ShortName switch
            {
                "room" => await db.Rooms.ToListAsync(),
                "crop" => await db.Crops.ToListAsync(),
                "plant" => await db.Plants.ToListAsync(),
                "strain" => await db.Strains.ToListAsync(),

                //"activity" => await db.PlantActivities.ToListAsync(),
                //"schedule" => await db.Schedules.ToListAsync(),
                _ => null
            };

            if (model == null)
            {
                return NotFound();
            }


            return PartialView($"_{tab.ViewPath}", model); // Dynamically load the correct partial view
        }
    }
}
