using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Job.Commands.CreateJob;
using HouseCostMonitor.Application.Job.Commands.EditJob;
using HouseCostMonitor.Application.Job.Dtos;
using HouseCostMonitor.Application.Job.Queries.GetJobById;
using HouseCostMonitor.Application.Job.Queries.GetJobs;
using MediatR;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/job")]
[Authorize]
public class JobController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<JobDto>>> GetAll(CancellationToken cancellationToken)
    {
        var jobs = await mediator.Send(new GetJobsQuery(), cancellationToken);
        return Ok(jobs);
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<JobDto>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var job = await mediator.Send(new GetJobById(id), cancellationToken);
        return Ok(job);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateJob(CreateJobCommand createJobCommand, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(createJobCommand, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditJob(Guid id, EditJobCommand editJobCommand, CancellationToken cancellationToken)
    {
        editJobCommand.Id = id;
        await mediator.Send(editJobCommand, cancellationToken);
        
        return NoContent();
    }
}