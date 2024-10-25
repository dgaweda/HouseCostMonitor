using HouseCostMonitor.Application.Services.User.Dtos;
using Microsoft.AspNetCore.Http;

namespace HouseCostMonitor.Application.Services.User;

internal class UserService(IHttpContextAccessor httpContextAccessor) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<UserDto> GetCurrentUser()
    {
        throw new NotImplementedException();
    }
}