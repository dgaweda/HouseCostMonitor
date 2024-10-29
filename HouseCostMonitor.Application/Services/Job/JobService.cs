using HouseCostMonitor.Application.Services.Job.Dtos;

namespace HouseCostMonitor.Application.Services.Job;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Domain.Repositories;

internal class JobService(IJobRepository jobRepository, IMapper mapper) : IJobService
{
    public async Task<IEnumerable<JobDto>> GetAllJobs()
    {
        return (await jobRepository.GetAllAsync())
            .AsQueryable()
            .ProjectTo<JobDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}