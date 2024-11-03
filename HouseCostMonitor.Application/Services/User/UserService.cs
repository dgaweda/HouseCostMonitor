using Microsoft.AspNetCore.Http;

namespace HouseCostMonitor.Application.Services.User;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Exceptions;
using HouseCostMonitor.Application.Services.Expense.Queries.GetExpenses;
using HouseCostMonitor.Application.Services.Job.Queries;
using HouseCostMonitor.Application.Services.User.Commands.CreateUser;
using HouseCostMonitor.Application.Services.User.Queries;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;

internal class UserService(IHttpContextAccessor httpContextAccessor, IUserRepository userRepository, IMapper mapper) : IUserService
{
    public async Task<IEnumerable<GetUsersQuery>> GetAllUsers(CancellationToken cancellationToken = default)
    {
        return (await userRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<GetUsersQuery>(mapper.ConfigurationProvider);
    }

    public async Task<GetUsersQuery?> GetUser(Guid id, CancellationToken cancellationToken = default)
    {
        var user = await userRepository.GetByIdAsync(id, cancellationToken);
        return user is null ? null : mapper.Map<GetUsersQuery>(user);
    }

    public async Task<GetUsersQuery> GetCurrentUser(CancellationToken cancellationToken = default)
    {
        var username = httpContextAccessor.HttpContext.User.Identity?.Name;
        if (string.IsNullOrWhiteSpace(username))
            throw new Exceptions.ApplicationException("Current user not found");

        var user = await userRepository.GetAsync(x => x.Username == username, cancellationToken);
        if (user is null)
            throw new Exceptions.ApplicationException("User not found");

        return mapper.Map<GetUsersQuery>(user);
    }

    public async Task<Guid> CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken = default)
    {
        var user = mapper.Map<User>(createUserCommand);
        var id = await userRepository.AddAsync(user, cancellationToken);
        return id;
    }

    public async Task<Guid> AddUserJobs(Guid userId, IEnumerable<GetJobsQuery> jobDtos, CancellationToken cancellationToken = default)
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