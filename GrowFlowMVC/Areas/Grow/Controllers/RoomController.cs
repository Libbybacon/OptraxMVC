using Microsoft.AspNetCore.Mvc;

namespace GrowFlowMVC.Areas.Grow.Controllers
{
    public class RoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
