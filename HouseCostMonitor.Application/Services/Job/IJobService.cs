namespace HouseCostMonitor.Application.Services.Job;

using HouseCostMonitor.Application.Services.Expense.Commands.CreateExpense;
using HouseCostMonitor.Application.Services.Job.Commands.CreateJob;
using HouseCostMonitor.Application.Services.Job.Commands.EditJob;
using HouseCostMonitor.Application.Services.Job.Queries;
using HouseCostMonitor.Domain.Enums;

public interface IJobService
{
    Task<IEnumerable<GetJobsQuery>> GetAllJobs(CancellationToken cancellationToken = default);
    Task<GetJobsQuery?> GetJob(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateJob(CreateJobCommand createJobCommand, CancellationToken cancellationToken = default);
    Task<Guid> EditJobInformation(Guid id, EditJobCommand editJobCommand, CancellationToken cancellationToken = default);
    Task<Guid> EditJobStatus(Guid jobId, JobStatus jobStatus, CancellationToken cancellationToken = default);
    Task<Guid> AddJobExpense(Guid id, CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken = default);
}