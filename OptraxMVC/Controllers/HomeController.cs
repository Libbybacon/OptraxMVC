using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Models.ViewModels;
using System.Diagnostics;

namespace OptraxMVC.Controllers;

[Authorize]
public class HomeController(OptraxContext context) : BaseController(context)
{

    [Authorize]
    public IActionResult Index()
    {

        return RedirectToAction("Index", "Grow", new { area = "Grow" });
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
