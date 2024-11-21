namespace HouseCostMonitor.Domain.Enums;

using System.ComponentModel;

public enum RoleType
{
    [Description("Admin")]
    Admin,
    
    [Description("Owner")]
    Owner,
    
    [Description("User")]
    User
}