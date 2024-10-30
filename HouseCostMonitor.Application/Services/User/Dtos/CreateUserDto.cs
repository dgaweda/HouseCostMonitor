namespace HouseCostMonitor.Application.Services.User.Dtos;

using HouseCostMonitor.Domain.Enums;

public record CreateUserDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Email { get; set; }
    public Role Role { get; set; }
    public string? Firstname { get; set; }
    public string? Lastname { get; set; }
}