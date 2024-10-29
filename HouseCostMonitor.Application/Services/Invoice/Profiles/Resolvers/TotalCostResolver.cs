namespace HouseCostMonitor.Application.Services.Invoice.Profiles.Resolvers;

using AutoMapper;
using HouseCostMonitor.Application.Services.Invoice.Dtos;
using HouseCostMonitor.Domain.Entities;

public class TotalCostResolver : IValueResolver<Invoice, InvoiceDto, decimal>
{
    public decimal Resolve(Invoice source, InvoiceDto destination, decimal destMember, ResolutionContext context)
    {
        source.CalculateTotalCost();

        return source.TotalCost;
    }
}