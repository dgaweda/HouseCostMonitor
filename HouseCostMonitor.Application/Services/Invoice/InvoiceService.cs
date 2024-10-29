using HouseCostMonitor.Application.Services.Invoice.Dtos;

namespace HouseCostMonitor.Application.Services.Invoice;

using AutoMapper;
using AutoMapper.QueryableExtensions;
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
}