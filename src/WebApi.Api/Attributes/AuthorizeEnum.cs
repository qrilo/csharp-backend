using Microsoft.AspNetCore.Authorization;
using MyApp.Data.Enums;

namespace WebApi.Api.Attributes;

public class AuthorizeEnum : AuthorizeAttribute
{
    public AuthorizeEnum(params UserRole[] roles)
    {
        Roles = string.Join(",", roles.Select(r => r.ToString()));
    }
}