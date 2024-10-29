using HouseCostMonitor.Application.Services.Invoice.Dtos;

namespace HouseCostMonitor.Application.Services.Invoice;

internal class InvoiceService(IInvoic) : IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAllInvoices();
    {
        throw new NotImplementedException();
    }
}