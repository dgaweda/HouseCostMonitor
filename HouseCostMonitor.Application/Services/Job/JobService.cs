using HouseCostMonitor.Application.Services.Job.Dtos;

namespace HouseCostMonitor.Application.Services.Job;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;

internal class JobService(IJobRepository jobRepository, IMapper mapper) : IJobService
{
    public async Task<IEnumerable<GetJobsQuery>> GetAllJobs(CancellationToken cancellationToken = default)
    {
        return (await jobRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<GetJobsQuery>(mapper.ConfigurationProvider)
            .ToList();
    }

    public async Task<GetJobsQuery?> GetJob(Guid id, CancellationToken cancellationToken = default)
    {
        var job = await jobRepository.GetByIdAsync(id, cancellationToken);
        return job is null ? null : mapper.Map<GetJobsQuery>(job);
    }

    public async Task<Guid> CreateJob(CreateJobCommand createJobCommand, CancellationToken cancellationToken = default)
    {
        var job = mapper.Map<Job>(createJobCommand);
        var id = await jobRepository.AddAsync(job, cancellationToken);
        return id;
    }

    public async Task<Guid> EditJobInformation(Guid jobId, EditJobCommand editJobCommand, CancellationToken cancellationToken = default)
    {
        editJobCommand.Id = jobId;
        
        var job = mapper.Map<Job>(editJobCommand);
        var id = await jobRepository.UpdateAsync(job, cancellationToken);
        return id;
    }

    public async Task<Guid> EditJobStatus(Guid jobId, JobStatus jobStatus, CancellationToken cancellationToken = default)
    {
        var job = await jobRepository.GetByIdAsync(jobId, cancellationToken);
        if (job is null)
            throw new ApplicationException($"Job with id - {jobId} - Not Found");
        
        job.SetJobStatus(jobStatus);
        var id = await jobRepository.UpdateAsync(job, cancellationToken);

        return id;
    }

    public async Task<Guid> AddJobExpense(Guid jobId, CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken = default)
    {
        var job = await jobRepository.GetByIdAsync(jobId, cancellationToken);
        if(job is null)
            throw new ApplicationException($"Job with id - {jobId} - Not Found");
        
        var expense = mapper.Map<Expense>(createExpenseCommand);
        job.AddJobExpense(expense);

        var id = await jobRepository.UpdateAsync(job, cancellationToken);
        return id;
    }
}