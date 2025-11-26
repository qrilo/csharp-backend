using MyApp.Data.Enums;

namespace MyApp.Data.Entities;

public class User
{
    public Guid Id { get; set; }
    public  string Username { get; set; }
    public string? Fullname { get; set; }
    public string PasswordHash { get; set; }
    public UserRole Role { get; set; }
}