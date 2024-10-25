using HouseCostMonitor.Application.Services.User.Dtos;

namespace HouseCostMonitor.Application.Services.User;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAll();
    Task<UserDto> GetCurrentUser();
}