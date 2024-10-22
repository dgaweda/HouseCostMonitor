using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Enums;

namespace HouseCostMonitor.Domain.Entities;

public class User : BaseEntity
{
    public string? Username { get; set; }
    public string PasswordHash { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }
    public string Fullname { get; set; }
    public DateTime LastLoginDate { get; set; }
    
    public List<Job> Jobs { get; set; }
}