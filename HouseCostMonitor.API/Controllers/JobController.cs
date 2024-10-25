using HouseCostMonitor.Application.Services.Expense;
using HouseCostMonitor.Application.Services.Job;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

[ApiController]
[Route("api/job")]
public class JobController(IJobService expenseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await expenseService.GetAllExpenses());
    }
}