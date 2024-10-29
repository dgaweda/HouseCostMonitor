using HouseCostMonitor.Application.Services.Job.Dtos;

namespace HouseCostMonitor.Application.Services.Job;

using AutoMapper;
using AutoMapper.QueryableExtensions;
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
}