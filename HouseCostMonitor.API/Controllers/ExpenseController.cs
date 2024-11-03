using HouseCostMonitor.Application.Services.Expense;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Services.Expense.Commands.CreateExpense;
using HouseCostMonitor.Application.Services.Expense.Commands.EditExpense;
using HouseCostMonitor.Application.Services.Expense.Commands.RemoveExpense;
using HouseCostMonitor.Application.Services.Expense.Queries.GetExpenseById;
using HouseCostMonitor.Application.Services.Expense.Queries.GetExpenses;
using MediatR;

[ApiController]
[Route("api/expense")]
public class ExpenseController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await mediator.Send(new GetExpensesQuery(), cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var expense = await mediator.Send(new GetExpenseByIdQuery(id), cancellationToken);
        if (expense is null)
            return NotFound();
        
        return Ok(expense);
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody]CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken)
    {
        var id = await mediator.Send(createExpenseCommand, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> RemoveExpense(Guid id, CancellationToken cancellationToken)
    {
        var isDeleted = await mediator.Send(new RemoveExpenseCommand(id), cancellationToken);
        if (isDeleted)
            return NoContent();
        
        return NotFound();
    }
    
    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> EditExpense(Guid id, EditExpenseCommand editExpenseCommand, CancellationToken cancellationToken)
    {
        editExpenseCommand.Id = id;
        var isUpdated = await mediator.Send(editExpenseCommand, cancellationToken);
        if (isUpdated)
            return NoContent();
        
        return NotFound();
    }
}