using HouseCostMonitor.Application.Services.Invoice.Dtos;

namespace HouseCostMonitor.Application.Services.Invoice;

using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;

public interface IInvoiceService
{
    Task<IEnumerable<InvoiceDto>> GetAllInvoices(CancellationToken cancellationToken = default);
    Task<InvoiceDto?> GetInvoice(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> EditInvoice(EditInvoiceDto editInvoiceDto, CancellationToken cancellationToken = default);
    Task<Guid> SetInvoiceStatus(Guid id, InvoiceStatus invoiceStatus, CancellationToken cancellationToken = default);
    Task<Guid> AddExpensesToInvoice(Guid invoiceId, IEnumerable<ExpenseDto> expenses, CancellationToken cancellationToken = default);
    Task<Guid> RemoveExpensesFromInvoice(Guid invoiceId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default);
}