namespace HouseCostMonitor.Application.Job.Commands.EditJobStatus;

using AutoMapper;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record EditJobStatusCommand(Guid Id, JobStatus JobStatus) : IRequest;

public class EditJobStatusCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<EditJobStatusCommand>
{
    public async Task Handle(EditJobStatusCommand request, CancellationToken cancellationToken)
    {
        var jobToUpdate = await jobRepository.GetByIdAsync(request.Id, cancellationToken);
        
        jobToUpdate.SetJobStatus(request.JobStatus);
        
        await jobRepository.UpdateAsync(jobToUpdate, cancellationToken);
    }
}