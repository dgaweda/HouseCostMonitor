using HouseCostMonitor.Application.Services.Job.Dtos;

namespace HouseCostMonitor.Application.Services.Job;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Services.Expense.Dtos;
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
        throw new NotImplementedException();
    }

    public async Task<Guid> CreateJob(CreateJobDto createJobDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> EditJobInformation(EditJobDto editJobDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> EditJobStatus(Guid id, JobStatus jobStatus, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddJobExpense(Guid id, AddExpenseDto addExpenseDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}