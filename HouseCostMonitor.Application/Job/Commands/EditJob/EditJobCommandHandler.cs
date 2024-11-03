namespace HouseCostMonitor.Application.Job.Commands.EditJob;

using AutoMapper;
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
        var jobToUpdate = await jobRepository.GetByIdAsync(request.Id, cancellationToken);
        if (jobToUpdate is null)
            return false;
        
        mapper.Map(request, jobToUpdate);
        await jobRepository.UpdateAsync(jobToUpdate, cancellationToken);
        return true;
    }
}