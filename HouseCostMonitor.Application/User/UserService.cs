namespace HouseCostMonitor.Application.User;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Exceptions;
using HouseCostMonitor.Application.Expense.Queries.GetExpenses;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Application.User.Commands.CreateUser;
using HouseCostMonitor.Application.User.Dtos;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using Microsoft.AspNetCore.Http;

internal class UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<UserDto> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        var username = httpContextAccessor.HttpContext.User.Identity?.Name;
        if (string.IsNullOrWhiteSpace(username))
            throw new ApplicationException("Current user not found");

        var user = await userRepository.GetAsync(x => x.Username == username, cancellationToken);
        if (user is null)
            throw new ApplicationException("User not found");

        return mapper.Map<UserDto>(user);
    }

    public async Task<Guid> AddUserJobs(Guid userId, IEnumerable<JobDto> jobDtos, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ApplicationException($"User with id - {userId} - Not found");
        
        var jobs = mapper.Map<IEnumerable<Job>>(jobDtos);
        user.AddJobs(jobs);

        var id = await userRepository.UpdateAsync(user, cancellationToken);
        return id;
    }

    public async Task<Guid> AddUserExpenses(Guid userId, IEnumerable<GetExpensesQuery> expenseDtos, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ApplicationException($"User with id - {userId} - Not found");
        
        var expenses = mapper.Map<IEnumerable<Expense>>(expenseDtos);
        user.AddExpenses(expenses);

        var id = await userRepository.UpdateAsync(user, cancellationToken);
        return id;
    }

    public async Task<Guid> RemoveUserJobs(Guid userId, IEnumerable<Guid> jobsIds, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ApplicationException($"User with id - {userId} - Not found");
        
        user.RemoveUserJobs(jobsIds);

        var id = await userRepository.UpdateAsync(user, cancellationToken);
        return id;
    }

    public async Task<Guid> RemoveUserExpenses(Guid userId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ApplicationException($"User with id - {userId} - Not found");
        
        user.RemoveUserExpenses(expensesIds);

        var id = await userRepository.UpdateAsync(user, cancellationToken);
        return id;
    }
}