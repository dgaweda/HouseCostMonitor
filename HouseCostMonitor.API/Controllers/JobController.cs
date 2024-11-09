using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Job.Commands.CreateJob;
using HouseCostMonitor.Application.Job.Commands.EditJob;
using HouseCostMonitor.Application.Job.Commands.EditJobStatus;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Application.Job.Queries.GetJobById;
using HouseCostMonitor.Application.Job.Queries.GetJobs;
using HouseCostMonitor.Domain.Enums;
using MediatR;

[ApiController]
[Route("api/job")]
public class JobController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetJobsQuery(), cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<JobDto?>> Get(Guid id, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new GetJobById(id), cancellationToken);
        if (job is null)
            return NotFound();
        
        return Ok(job);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateJob(CreateJobCommand createJobCommand, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(createJobCommand, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditJobInformation(Guid id, EditJobCommand editJobCommand, CancellationToken cancellationToken)
    {
        editJobCommand.Id = id;
        await mediator.Send(editJobCommand, cancellationToken);
        
        return NoContent();
    }
    
    [HttpPatch("status/{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditJobInformation(Guid id, JobStatus jobStatus, CancellationToken cancellationToken)
    {
        var editJobStatusCommand = new EditJobStatusCommand(id, jobStatus);
        await mediator.Send(editJobStatusCommand, cancellationToken);
 
        return NoContent();
    }
}