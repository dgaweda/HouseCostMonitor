namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.User.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/user")]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpPatch]
    [Authorize]
    public async Task<IActionResult> UpdateUserDetails(UpdateUserDetailsCommand command, CancellationToken cancellationToken)
    {
        await mediator.Send(command, cancellationToken);
        return NoContent();
    }
}