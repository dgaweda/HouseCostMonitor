namespace HouseCostMonitor.Application.Job.Queries.GetJobs;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetJobsQuery : IRequest<IEnumerable<JobDto>>;

public class GetJobsQueryHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<GetJobsQuery, IEnumerable<JobDto>>
{
    public async Task<IEnumerable<JobDto>> Handle(GetJobsQuery request, CancellationToken cancellationToken)
    {
        var jobs = await jobRepository.GetAllAsync(cancellationToken: cancellationToken);
        return jobs
            .AsQueryable()
            .ProjectTo<JobDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}