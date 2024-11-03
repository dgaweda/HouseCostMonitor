using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.User.Commands.CreateUser;
using HouseCostMonitor.Application.User.Dtos;
using HouseCostMonitor.Application.User.Queries.GetUserById;
using HouseCostMonitor.Application.User.Queries.GetUsers;
using MediatR;

[ApiController]
[Route("api/user")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetUsersQuery(), cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<UserDto?>> Get(Guid id, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        if (user is null)
            return NotFound();
        
        return Ok(user);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser(CreateUserCommand createUserCommand, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(createUserCommand, cancellationToken);
        return CreatedAtAction(nameof(Get), new { id }, null);
    }
    
    // TODO: Implement rest of the methods
}