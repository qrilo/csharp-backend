using System.Security.Claims;
using MyApp.Data.Enums;
using WebApi.Api.Interfaces;

namespace WebApi.Api.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid UserId
    {
        get
        {
            var idClaim = _httpContextAccessor.HttpContext?.User?.FindFirst("id")?.Value;
            if (string.IsNullOrEmpty(idClaim) || !Guid.TryParse(idClaim, out var guid))
            {
                throw new UnauthorizedAccessException("User ID claim is missing or invalid");
            }

            return guid;
        }
    }

    public UserRole Role
    {
        get
        {
            var roleClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value;

            if (string.IsNullOrEmpty(roleClaim) || !Enum.TryParse<UserRole>(roleClaim, ignoreCase: true, out var role))
            {
                throw new UnauthorizedAccessException("User role claim is missing or invalid");
            }

            return role;
        }
    }
}