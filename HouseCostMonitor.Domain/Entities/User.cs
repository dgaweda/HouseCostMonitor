using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class User
{
    public Guid Id { get; set; }
    public string? Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string Fullname { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastLoginDate { get; set; }
}