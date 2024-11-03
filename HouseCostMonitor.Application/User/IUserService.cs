namespace HouseCostMonitor.Application.User;

using HouseCostMonitor.Application.Expense.Queries.GetExpenses;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Application.User.Dtos;

public interface IUserService
{
    Task<UserDto> GetCurrentUser(CancellationToken cancellationToken = default);
    Task<Guid> AddUserJobs(Guid userId, IEnumerable<JobDto> jobDtos, CancellationToken cancellationToken = default);
    Task<Guid> AddUserExpenses(Guid userId, IEnumerable<GetExpensesQuery> jobDtos, CancellationToken cancellationToken = default);
    Task<Guid> RemoveUserJobs(Guid userId, IEnumerable<Guid> jobsIds, CancellationToken cancellationToken = default);
    Task<Guid> RemoveUserExpenses(Guid userId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default);
}