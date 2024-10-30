using HouseCostMonitor.Application.Services.Job;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Services.Job.Dtos;
using HouseCostMonitor.Domain.Repositories;

[ApiController]
[Route("api/job")]
public class JobController(IJobService jobService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await jobService.GetAllJobs(cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var job = await jobService.GetJob(id, cancellationToken);
        if (job is null)
            return NotFound(id);
        
        return Ok(job);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJob(CreateJobDto createJobDto, CancellationToken cancellationToken)
    {
        var id = await jobService.CreateJob(createJobDto, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
}