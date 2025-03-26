using OptraxDAL;
using System.Security.Claims;

namespace OptraxMVC.Services
{
    public class CurrentUserService(IHttpContextAccessor accessor) : ICurrentUserService
    {
        private readonly IHttpContextAccessor _accessor = accessor;

        public string UserID => _accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
    }
}
