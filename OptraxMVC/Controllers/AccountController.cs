using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Services;

namespace OptraxMVC.Controllers
{
    public class AccountController(OptraxContext context, IDropdownService dropdownService) : BaseController(context, dropdownService)
    {

        [HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
