using Microsoft.AspNetCore.Mvc;

namespace GrowFlowMVC.Controllers
{
    public class BaseController : Controller
    {
        protected readonly GrowFlowContext db;
        
        protected BaseController(GrowFlowContext context)
        {
            db = context;
        }

    }
}
