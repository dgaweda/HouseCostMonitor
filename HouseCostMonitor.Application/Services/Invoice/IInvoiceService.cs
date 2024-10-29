using HouseCostMonitor.Application.Services.Invoice.Dtos;

namespace HouseCostMonitor.Application.Services.Invoice;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAllInvoices(CancellationToken cancellationToken = default);
}