namespace WebApi.Api.Models.Response;

public class LoginResponse
{
    public Guid Id { get; set; }
    public string AccessToken { get; set; }
    public string Role { get; set; }
}