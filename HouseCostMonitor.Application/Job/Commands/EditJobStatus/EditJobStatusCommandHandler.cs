namespace HouseCostMonitor.Application.Job.Commands.EditJobStatus;

using AutoMapper;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;
using MediatR;

public record EditJobStatusCommand(Guid Id, JobStatus JobStatus) : IRequest<bool>;

public class EditJobStatusCommandHandler(IMapper mapper, IJobRepository jobRepository) : IRequestHandler<EditJobStatusCommand, bool>
{
    public async Task<bool> Handle(EditJobStatusCommand request, CancellationToken cancellationToken)
    {
        var jobToUpdate = await jobRepository.GetByIdAsync(request.Id, cancellationToken);
        if (jobToUpdate is null)
            return false;
        
        jobToUpdate.SetJobStatus(request.JobStatus);
        
        await jobRepository.UpdateAsync(jobToUpdate, cancellationToken);
        return true;
    }
}