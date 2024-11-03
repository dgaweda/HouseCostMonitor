namespace HouseCostMonitor.Application.Services.User.Commands.CreateUser;

using HouseCostMonitor.Domain.Enums;

public record CreateUserCommand
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
}