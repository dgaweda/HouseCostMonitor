namespace HouseCostMonitor.Domain.Enums;

using System.ComponentModel;
using HouseCostMonitor.Domain.Constants;

public enum RoleType
{
    [Description(Roles.Admin)]
    Admin,
    
    [Description(Roles.Owner)]
    Owner,
    
    [Description(Roles.User)]
    User
}