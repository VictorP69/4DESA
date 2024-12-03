using System.Security.Claims;

namespace social_media.Services.AuthService
{
    public class AuthService(IHttpContextAccessor httpContextAccessor) : IAuthService
    {
        public bool canUserAcessResource(string userId)
        {
            var authenticatedUserId = httpContextAccessor.HttpContext?.User
                .FindFirst(ClaimTypes.NameIdentifier)?.Value;

            return authenticatedUserId != null && authenticatedUserId == userId;
        }
    }
}
