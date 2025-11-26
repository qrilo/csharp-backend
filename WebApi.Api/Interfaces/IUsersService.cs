using WebApi.Api.Models.Request;
using WebApi.Api.Models.Response;

namespace WebApi.Api.Interfaces;

public interface IUsersService
{
    public Task<LoginResponse> Login(LoginRequest request);
    public Task<CreateUserResponse> Register(CreateUserRequest request);
}