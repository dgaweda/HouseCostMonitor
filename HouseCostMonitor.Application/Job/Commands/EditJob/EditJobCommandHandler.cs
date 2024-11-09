namespace HouseCostMonitor.Application.Job.Commands.EditJob;

using AutoMapper;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record EditJobCommand : IRequest
{
    public Guid Id { get; set; }
    public string? Description { get; init; }
    public TimeSpan? Duration { get; init; }
}

public class EditJobCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<EditJobCommand>
{
    public async Task Handle(EditJobCommand request, CancellationToken cancellationToken)
    {
        var jobToUpdate = await jobRepository.GetByIdAsync(request.Id, cancellationToken);
        
        mapper.Map(request, jobToUpdate);
        await jobRepository.UpdateAsync(jobToUpdate, cancellationToken);
    }
}