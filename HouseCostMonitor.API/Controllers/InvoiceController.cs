using HouseCostMonitor.Application.Services.Expense;
using HouseCostMonitor.Application.Services.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

[ApiController]
[Route("api/invoice")]
public class InvoiceController(IInvoiceService expenseService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await expenseService.GetAllExpenses());
    }
}