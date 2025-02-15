using OptraxMVC.Controllers;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using Microsoft.AspNetCore.Authorization;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class GrowController(OptraxContext context) : BaseController(context)
    {
        [Authorize]
        public IActionResult Index()
        {
            var rooms = db.Rooms.ToList();

            ViewBag.Rooms = rooms;

            return View();
        }
    }
}
