using HouseCostMonitor.Application.Services.Invoice.Dtos;

namespace HouseCostMonitor.Application.Services.Invoice;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Enums;
using HouseCostMonitor.Domain.Repositories;

internal class InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper) : IInvoiceService
{
    public async Task<IEnumerable<InvoiceDto>> GetAllInvoices(CancellationToken cancellationToken = default)
    {
        return (await invoiceRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<InvoiceDto>(mapper.ConfigurationProvider)
            .ToList();
    }

    public async Task<InvoiceDto?> GetInvoice(Guid id, CancellationToken cancellationToken = default)
    {
        var invoice = await invoiceRepository.GetByIdAsync(id, cancellationToken);
        return invoice is null ? null : mapper.Map<InvoiceDto>(invoice);
    }

    public async Task<Guid> EditInvoice(EditInvoiceDto editInvoiceDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> SetInvoiceStatus(Guid id, InvoiceStatus invoiceStatus, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> AddExpensesToInvoice(Guid invoiceId, IEnumerable<ExpenseDto> expenses, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> RemoveExpensesFromInvoice(Guid invoiceId, IEnumerable<Guid> expensesIds, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}