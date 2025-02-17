using Microsoft.AspNetCore.Mvc;

namespace OptraxMVC.Areas.Inventory.Controllers
{
    public class InventoryItemsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
