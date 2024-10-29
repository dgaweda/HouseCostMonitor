using HouseCostMonitor.Application.Services.User.Dtos;
using Microsoft.AspNetCore.Http;

namespace HouseCostMonitor.Application.Services.User;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Domain.Repositories;

internal class UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<IEnumerable<UserDto>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        return (await userRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<UserDto>(mapper.ConfigurationProvider);
    }

    public async Task<UserDto> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        var username = httpContextAccessor.HttpContext.User.Identity?.Name;
        if (string.IsNullOrWhiteSpace(username))
            throw new Exceptions.ApplicationException("Current user not found");

        var user = await userRepository.GetAsync(x => x.Username == username, cancellationToken);
        if (user is null)
            throw new Exceptions.ApplicationException("User not found");

        return mapper.Map<UserDto>(user);
    }
}