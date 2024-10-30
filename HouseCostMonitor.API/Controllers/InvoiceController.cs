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

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetInvoice(Guid id, CancellationToken cancellationToken)
    {
        var invoice = await invoiceService.GetInvoice(id, cancellationToken);
        if (invoice is null)
            return NotFound(id);

        return Ok(invoice);
    }
}