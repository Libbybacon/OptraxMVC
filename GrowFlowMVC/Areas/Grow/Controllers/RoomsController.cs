using GrowFlowMVC.Controllers;
using Microsoft.AspNetCore.Mvc;

namespace GrowFlowMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class RoomsController : BaseController
    {
        public RoomsController(GrowFlowContext context) : base(context)
        {
        }

        public IActionResult Index()
        {
            var rooms = db.Rooms.ToList();

            return PartialView("_Rooms", rooms);
        }
    }
}
