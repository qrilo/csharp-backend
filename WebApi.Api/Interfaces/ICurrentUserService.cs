using MyApp.Data.Enums;

namespace WebApi.Api.Interfaces;

public interface ICurrentUserService
{
    Guid UserId { get; }
    UserRole Role { get; }
}