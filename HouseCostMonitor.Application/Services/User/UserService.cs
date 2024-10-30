using HouseCostMonitor.Application.Services.User.Dtos;
using Microsoft.AspNetCore.Http;

namespace HouseCostMonitor.Application.Services.User;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Job.Dtos;
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

    public async Task<Guid> CreateUser(CreateUserDto createUserDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddUserJobs(Guid userId, IEnumerable<JobDto> jobDtos, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddUserExpenses(Guid userId, IEnumerable<ExpenseDto> jobDtos, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> RemoveUserJobs(Guid userId, IEnumerable<Guid> jobsIds, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> RemoveUserExpenses(Guid userId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}