namespace HouseCostMonitor.Application.Services.Invoice.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.Services.Invoice.Dtos;
using HouseCostMonitor.Application.Services.Invoice.Profiles.Resolvers;
using HouseCostMonitor.Domain.Entities;

public class InvoiceProfile : Profile
{
    public InvoiceProfile()
    {
        CreateMap<Invoice, InvoiceDto>()
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom<TotalCostResolver>());
    }
}