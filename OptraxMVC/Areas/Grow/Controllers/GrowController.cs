using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Controllers;
using OptraxMVC.Models;
using OptraxMVC.Services;

namespace OptraxMVC.Areas.Grow.Controllers
{
    [Area("Grow")]
    public class GrowController(OptraxContext context, IDropdownService dropdownService) : BaseController(context, dropdownService)
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
