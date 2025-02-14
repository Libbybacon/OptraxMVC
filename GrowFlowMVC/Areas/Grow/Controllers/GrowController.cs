using GrowFlowMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GrowFlowMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class GrowController : BaseController
    {
        public GrowController(GrowFlowContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            var rooms = db.Rooms.ToList();

            ViewBag.Rooms = rooms;

            return View();
        }
    }
}
