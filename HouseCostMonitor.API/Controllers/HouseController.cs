namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Extensions.House.Queries;
using HouseCostMonitor.Application.House.Dtos;
using HouseCostMonitor.Application.House.Queries;
using HouseCostMonitor.Domain.Constants;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/house")]
[Authorize]
public class HouseController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<HouseDto>>> GetHouses(CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetHousesQuery(), cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<HouseDto>> GetHouseById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetHouseByIdQuery(id);
        var result = await mediator.Send(query, cancellationToken);

        return Ok(result);
    }
}