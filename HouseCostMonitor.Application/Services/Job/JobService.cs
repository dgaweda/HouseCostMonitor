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
    public async Task<IEnumerable<JobDto>> GetAllJobs(CancellationToken cancellationToken = default)
    {
        return (await jobRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<JobDto>(mapper.ConfigurationProvider)
            .ToList();
    }

    public async Task<JobDto?> GetJob(Guid id, CancellationToken cancellationToken = default)
    {
        var job = await jobRepository.GetByIdAsync(id, cancellationToken);
        return job is null ? null : mapper.Map<JobDto>(job);
    }

    public async Task<Guid> CreateJob(CreateJobDto createJobDto, CancellationToken cancellationToken = default)
    {
        var job = mapper.Map<Job>(createJobDto);
        var id = await jobRepository.AddAsync(job, cancellationToken);
        return id;
    }

    public async Task<Guid> EditJobInformation(Guid jobId, EditJobDto editJobDto, CancellationToken cancellationToken = default)
    {
        editJobDto.Id = jobId;
        
        var job = mapper.Map<Job>(editJobDto);
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

    public async Task<Guid> AddJobExpense(Guid jobId, CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default)
    {
        var job = await jobRepository.GetByIdAsync(jobId, cancellationToken);
        if(job is null)
            throw new ApplicationException($"Job with id - {jobId} - Not Found");
        
        var expense = mapper.Map<Expense>(createExpenseDto);
        job.AddJobExpense(expense);

        var id = await jobRepository.UpdateAsync(job, cancellationToken);
        return id;
    }
}