namespace HouseCostMonitor.Application.User;

using HouseCostMonitor.Domain.Enums;

public record CurrentUser(string Id, string Email, IEnumerable<string> Roles)
{
    public bool IsInRole(string role) => Roles.Contains(role);
}