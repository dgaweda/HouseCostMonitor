using HouseCostMonitor.Application.Services.Job.Dtos;

namespace HouseCostMonitor.Application.Services.Job;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;

public interface IJobService
{
    Task<IEnumerable<JobDto>> GetAllJobs(CancellationToken cancellationToken = default);
    Task<JobDto?> GetJob(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateJob(CreateJobDto createJobDto, CancellationToken cancellationToken = default);
    Task<Guid> EditJobInformation(EditJobDto editJobDto, CancellationToken cancellationToken = default);
    Task<Guid> EditJobStatus(Guid id, JobStatus jobStatus, CancellationToken cancellationToken = default);
    Task<Guid> AddJobExpense(Guid id, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default);
}