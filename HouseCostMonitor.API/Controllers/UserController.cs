using HouseCostMonitor.Application.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Services.Job.Dtos;
using HouseCostMonitor.Application.Services.User.Dtos;

[ApiController]
[Route("api/user")]
public class UserController(IUserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await userService.GetAllUsers(cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var user = await userService.GetUser(id, cancellationToken);
        if (user is null)
            return NotFound(id);
        
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var id = await userService.CreateUser(createUserCommand, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
}