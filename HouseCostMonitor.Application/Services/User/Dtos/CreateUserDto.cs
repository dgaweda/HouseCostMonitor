namespace HouseCostMonitor.Application.Services.User.Dtos;

using HouseCostMonitor.Domain.Enums;

public record CreateUserDto
{
    public string Username { get; set; } = default!;
    public string Password { get; set; }
    public string Email { get; set; } = default!;
    public Role Role { get; set; }
    public string Firstname { get; set; } = default!;
    public string Lastname { get; set; } = default!;
}