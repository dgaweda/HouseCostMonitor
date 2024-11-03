namespace HouseCostMonitor.Application.Services.Job.Commands.EditJob;

using AutoMapper;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record EditJobCommand : IRequest<bool>
{
    public Guid Id { get; set; }
    public string? Description { get; init; }
    public TimeSpan? Duration { get; init; }
}

public class EditJobCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<EditJobCommand, bool>
{
    public async Task<bool> Handle(EditJobCommand request, CancellationToken cancellationToken)
    {
        var job = mapper.Map<Job>(request);
        var jobToUpdate = await jobRepository.GetByIdAsync(request.Id, cancellationToken);
        if (jobToUpdate is null)
            return false;
        
        await jobRepository.UpdateAsync(job, cancellationToken);
        return true;
    }
}