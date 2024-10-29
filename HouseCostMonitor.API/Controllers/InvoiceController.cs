using HouseCostMonitor.Application.Services.Invoice;
using Microsoft.AspNetCore.Mvc;

namespace HouseCostMonitor.API.Controllers;

[ApiController]
[Route("api/invoice")]
public class InvoiceController(IInvoiceService invoiceService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        return Ok(await invoiceService.GetAllInvoices(cancellationToken));
    }
}