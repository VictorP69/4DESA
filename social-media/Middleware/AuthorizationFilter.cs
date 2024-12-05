using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using social_media.Services.AuthService;

namespace social_media.Middleware
{
    public class AuthorizationFilter(IAuthService authService) : IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userId = context.RouteData.Values["userId"]?.ToString();
            if (userId != null && !authService.canUserAcessResource(userId))
            {
                context.Result = new UnauthorizedResult();
            }
        }
    }
}
