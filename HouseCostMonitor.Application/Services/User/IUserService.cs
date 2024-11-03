using HouseCostMonitor.Application.Services.User.Dtos;

namespace HouseCostMonitor.Application.Services.User;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Job.Dtos;

public interface IUserService
{
    Task<IEnumerable<GetUsersQuery>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<GetUsersQuery?> GetUser(Guid id, CancellationToken cancellationToken = default);
    Task<GetUsersQuery> GetCurrentUser(CancellationToken cancellationToken = default);
    Task<Guid> CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken = default);
    Task<Guid> AddUserJobs(Guid userId, IEnumerable<GetJobsQuery> jobDtos, CancellationToken cancellationToken = default);
    Task<Guid> AddUserExpenses(Guid userId, IEnumerable<GetExpenseQuery> jobDtos, CancellationToken cancellationToken = default);
    Task<Guid> RemoveUserJobs(Guid userId, IEnumerable<Guid> jobsIds, CancellationToken cancellationToken = default);
    Task<Guid> RemoveUserExpenses(Guid userId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default);
}