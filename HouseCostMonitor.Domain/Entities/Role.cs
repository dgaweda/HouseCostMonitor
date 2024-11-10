namespace HouseCostMonitor.Domain.Entities;

using HouseCostMonitor.Domain.Enums;
using Microsoft.AspNetCore.Identity;

public class Role : IdentityRole<Guid>
{
    public RoleType RoleType { get; set; }
}