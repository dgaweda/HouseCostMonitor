using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Services.Job.Commands.CreateJob;
using HouseCostMonitor.Application.Services.Job.Commands.EditJob;
using HouseCostMonitor.Application.Services.Job.Commands.EditJobStatus;
using HouseCostMonitor.Application.Services.Job.Queries.GetJobById;
using HouseCostMonitor.Application.Services.Job.Queries.GetJobs;
using HouseCostMonitor.Domain.Enums;
using MediatR;

[ApiController]
[Route("api/job")]
public class JobController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetJobsQuery(), cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new GetJobById(id), cancellationToken);
        if (job is null)
            return NotFound();
        
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob(CreateJobCommand createJobCommand, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(createJobCommand, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> EditJobInformation(Guid id, EditJobCommand editJobCommand, CancellationToken cancellationToken)
    {
        editJobCommand.Id = id;
        var idUpdated = await mediator.Send(editJobCommand, cancellationToken);
        if (idUpdated)
            return NoContent();

        return NotFound();
    }
    
    [HttpPatch("status/{id:guid}")]
    public async Task<IActionResult> EditJobInformation(Guid id, JobStatus jobStatus, CancellationToken cancellationToken)
    {
        var editJobStatusCommand = new EditJobStatusCommand(id, jobStatus);
        var idUpdated = await mediator.Send(editJobStatusCommand, cancellationToken);
        if (idUpdated)
            return NoContent();

        return NotFound();
    }
}