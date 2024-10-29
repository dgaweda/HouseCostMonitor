using HouseCostMonitor.Application.Services.Expense;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

[ApiController]
[Route("api/expense")]
public class ExpenseController(IExpenseService expenseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await expenseService.GetAllExpenses(cancellationToken));
    }
}