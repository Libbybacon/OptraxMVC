using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Filters;
using OptraxDAL;
using System.Security.Claims;

namespace OptraxMVC.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        protected readonly OptraxContext db;

        private string? _userID;
        protected string UserID
        {
            get
            {
                _userID ??= User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                return _userID;
            }
        }

        protected BaseController(OptraxContext context)
        {
            db = context;
        }

        public object ResponseVM(bool success)
        {
            return new { success };
        }
        public object ResponseVM(string msg, bool success = false)
        {
            return new { success, msg };
        }

        public object ResponseVM(object data)
        {
            return new { success = true, data };
        }

        public override void OnActionExecuting(ActionExecutingContext execContext)
        {
            if (string.IsNullOrEmpty(UserID))
                return;

            base.OnActionExecuting(execContext);
        }
    }
}
