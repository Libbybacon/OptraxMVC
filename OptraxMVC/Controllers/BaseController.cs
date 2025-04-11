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

        private string? _userId;
        protected string UserId
        {
            get
            {
                _userId ??= User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
                return _userId;
            }
        }

        protected BaseController(OptraxContext context)
        {
            db = context;
        }

        public object JsonVM(bool success)
        {
            return new { success };
        }
        public object JsonVM(string msg, bool success = false)
        {
            return new { success, msg };
        }

        public object JsonVM(object data)
        {
            return new { success = true, data };
        }

        public override void OnActionExecuting(ActionExecutingContext execContext)
        {
            if (string.IsNullOrEmpty(UserId))
                return;

            base.OnActionExecuting(execContext);
        }
    }
}
