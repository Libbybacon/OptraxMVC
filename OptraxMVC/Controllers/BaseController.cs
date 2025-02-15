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

    }
}
