namespace HouseCostMonitor.Application.Services.Expense.Profiles.Resolvers;

using AutoMapper;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Expense.Queries.GetExpenses;
using HouseCostMonitor.Domain.Entities;

public class TotalCostResolver : IValueResolver<Expense, ExpenseDto, decimal>
{
    public decimal Resolve(Expense source, ExpenseDto destination, decimal destMember, ResolutionContext context)
    {
        source.CalculateTotalCost();
        return source.TotalCost;
    }
}