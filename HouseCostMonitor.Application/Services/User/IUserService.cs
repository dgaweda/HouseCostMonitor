using HouseCostMonitor.Application.Services.User.Dtos;

namespace HouseCostMonitor.Application.Services.User;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Job.Dtos;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsers(CancellationToken cancellationToken = default);
    Task<UserDto?> GetUser(Guid id, CancellationToken cancellationToken = default);
    Task<UserDto> GetCurrentUser(CancellationToken cancellationToken = default);
    Task<Guid> CreateUser(CreateUserDto createUserDto, CancellationToken cancellationToken = default);
    Task<Guid> AddUserJobs(Guid userId, IEnumerable<JobDto> jobDtos, CancellationToken cancellationToken = default);
    Task<Guid> AddUserExpenses(Guid userId, IEnumerable<ExpenseDto> jobDtos, CancellationToken cancellationToken = default);
    Task<Guid> RemoveUserJobs(Guid userId, IEnumerable<Guid> jobsIds, CancellationToken cancellationToken = default);
    Task<Guid> RemoveUserExpenses(Guid userId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default);
}