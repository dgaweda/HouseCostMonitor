using HouseCostMonitor.Application.Services.Expense;
using HouseCostMonitor.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

[ApiController]
[Route("api/expense")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await userService.GetAllExpenses());
    }
}