using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Expense.Commands.CreateExpense;
using HouseCostMonitor.Application.Expense.Commands.EditExpense;
using HouseCostMonitor.Application.Expense.Commands.RemoveExpense;
using HouseCostMonitor.Application.Expense.Dtos;
using HouseCostMonitor.Application.Expense.Queries.GetExpenseById;
using HouseCostMonitor.Application.Expense.Queries.GetExpenses;
using MediatR;

[ApiController]
[Route("api/expense")]
public class ExpenseController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetExpensesQuery(), cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<ExpenseDto?>> GetById(Guid id, CancellationToken cancellationToken)
    {
        var expense = await mediator.Send(new GetExpenseByIdQuery(id), cancellationToken);
        return Ok(expense);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateExpense([FromBody]CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(createExpenseCommand, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
    
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> RemoveExpense(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new RemoveExpenseCommand(id), cancellationToken);
        return NoContent();
    }
    
    [HttpPatch("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> EditExpense(Guid id, EditExpenseCommand editExpenseCommand, CancellationToken cancellationToken)
    {
        editExpenseCommand.Id = id;
        await mediator.Send(editExpenseCommand, cancellationToken);

        return NoContent();
    }
}