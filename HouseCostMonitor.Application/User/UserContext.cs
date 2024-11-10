namespace HouseCostMonitor.Application.User;

using System.Security.Claims;
using Microsoft.AspNetCore.Http;

public interface IUserContext
{
    CurrentUser? GetCurrentUser();
}

public class UserContext(IHttpContextAccessor httpContextAccessor) : IUserContext
{
    public CurrentUser? GetCurrentUser()
    {
        var user = httpContextAccessor?.HttpContext?.User;
        if (user is null)
            throw new InvalidOperationException("User context is not present");

        if (user.Identity is not { IsAuthenticated: true })
            return null;

        var userId = user.FindFirst(c => c.Type == ClaimTypes.NameIdentifier)!.Value;
        var email = user.FindFirst(c => c.Type == ClaimTypes.Email)!.Value;
        var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role)!.Select(c => c.Value);

        return new CurrentUser(userId, email, roles);
    }
}