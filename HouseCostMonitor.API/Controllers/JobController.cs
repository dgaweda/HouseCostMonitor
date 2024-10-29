using HouseCostMonitor.Application.Services.Job;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

[ApiController]
[Route("api/job")]
public class JobController(IJobService jobService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await jobService.GetAllJobs());
    }
}