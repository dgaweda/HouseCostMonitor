using HouseCostMonitor.Application.Services.Invoice.Dtos;

namespace HouseCostMonitor.Application.Services.Invoice;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Domain.Repositories;

internal class InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper) : IInvoiceService
{
    public async Task<IEnumerable<InvoiceDto>> GetAllInvoices()
    {
        return (await invoiceRepository.GetAllAsync())
            .AsQueryable()
            .ProjectTo<InvoiceDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}