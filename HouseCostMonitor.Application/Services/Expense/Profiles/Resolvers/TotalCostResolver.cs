namespace HouseCostMonitor.Application.Services.Expense.Profiles.Resolvers;

using AutoMapper;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Entities;

public class TotalCostResolver : IValueResolver<Expense, GetExpenseQuery, decimal>
{
    public decimal Resolve(Expense source, GetExpenseQuery destination, decimal destMember, ResolutionContext context)
    {
        source.CalculateTotalCost();
        return source.TotalCost;
    }
}