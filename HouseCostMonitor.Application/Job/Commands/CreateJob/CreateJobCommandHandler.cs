namespace HouseCostMonitor.Application.Job.Commands.CreateJob;

using AutoMapper;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record CreateJobCommand : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string? Description { get; set; }
    public TimeSpan? Duration { get; set; }
    public JobStatus JobStatus { get; set; }
}

public class CreateJobCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<CreateJobCommand, Guid>
{
    public async Task<Guid> Handle(CreateJobCommand request, CancellationToken cancellationToken)
    {
        var job = mapper.Map<Job>(request);
        var id = await jobRepository.AddAsync(job, cancellationToken);
        return id;
    }
}