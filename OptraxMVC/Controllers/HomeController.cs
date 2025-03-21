using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;
using OptraxMVC.Models;
using OptraxMVC.Services;
using System.Diagnostics;
using System.Security.Cryptography;

namespace OptraxMVC.Controllers;

[Authorize]
public class HomeController(OptraxContext context) : BaseController(context)
{

    [Authorize]
    public IActionResult Index()
    {
        return View();  // If logged in, show the page (Home/Index)
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
