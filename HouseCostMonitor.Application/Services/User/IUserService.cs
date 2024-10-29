using HouseCostMonitor.Application.Services.User.Dtos;

namespace HouseCostMonitor.Application.Services.User;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<UserDto> GetCurrentUser(CancellationToken cancellationToken = default);
}