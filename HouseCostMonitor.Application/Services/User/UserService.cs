using HouseCostMonitor.Application.Services.User.Dtos;
using Microsoft.AspNetCore.Http;

namespace HouseCostMonitor.Application.Services.User;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Domain.Repositories;

internal class UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAllUsers()
    {
        return (await userRepository.GetAllAsync())
            .AsQueryable()
            .ProjectTo<UserDto>(mapper.ConfigurationProvider);
    }

    public async Task<UserDto> GetCurrentUser()
    {
        var username = httpContextAccessor.HttpContext.User.Identity?.Name;
        if (string.IsNullOrWhiteSpace(username))
            throw new Exceptions.ApplicationException("Current user not found");

        var user = await userRepository.GetAsync(x => x.Username == username);
        if (user is null)
            throw new Exceptions.ApplicationException("User not found");

        return mapper.Map<UserDto>(user);
    }
}