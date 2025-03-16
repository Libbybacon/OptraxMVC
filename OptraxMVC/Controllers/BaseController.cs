using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Filters;
using OptraxDAL;
using OptraxDAL.Models.Admin;
using OptraxMVC.Services;
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

        public override void OnActionExecuting(ActionExecutingContext execContext)
        {
            if (string.IsNullOrEmpty(UserID))
                return;

            base.OnActionExecuting(execContext);
        }
    }
}
