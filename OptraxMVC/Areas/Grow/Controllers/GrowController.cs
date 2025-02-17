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
            return View();
        }

        public ActionResult LoadTabContent(Tab tab)
        {
            return View();
        }
    }
}
