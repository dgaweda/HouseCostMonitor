using HouseCostMonitor.Application.Services.Expense;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

using HouseCostMonitor.Application.Services.Expense.Dtos;

[ApiController]
[Route("api/expense")]
public class ExpenseController(IExpenseService expenseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await expenseService.GetAllExpenses(cancellationToken));
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        return Ok(await expenseService.GetExpenseById(id, cancellationToken));
    }

    [HttpPost]
    public async Task<IActionResult> CreateExpense([FromBody]AddExpenseDto addExpenseDto, CancellationToken cancellationToken)
    {
        var id = await expenseService.CreateExpense(addExpenseDto, cancellationToken);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}