namespace HouseCostMonitor.Application.Job.Queries.GetJobById;

using AutoMapper;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record GetJobById(Guid Id) : IRequest<JobDto>;

public class GetJobByIdQueryHandler(IMapper mapper, IJobRepository jobRepository)  : IRequestHandler<GetJobById, JobDto>
{
    public async Task<JobDto> Handle(GetJobById request, CancellationToken cancellationToken)
    {
        var job = await jobRepository.GetByIdAsync(request.Id, cancellationToken);
        return mapper.Map<JobDto>(job);
    }
}