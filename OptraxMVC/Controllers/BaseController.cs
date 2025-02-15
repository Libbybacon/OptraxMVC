using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptraxDAL;

namespace OptraxMVC.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly OptraxContext db;

        protected BaseController(OptraxContext context)
        {
            db = context;
        }

        public Dictionary<string, string> GetMenuItems()
        {
            return new Dictionary<string, string>() {
                { "Home", "grid-3x3" },
                { "Grow", "flower2" },
                { "Harvest", "scissors" },
                { "Inventory", "basket3" },
                { "Reports", "file-bar-graph" },
            };

        }
    }
}
