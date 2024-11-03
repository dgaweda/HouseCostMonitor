namespace HouseCostMonitor.Application.Services.Expense.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.Services.Expense.Commands.CreateExpense;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Application.Services.Expense.Profiles.Resolvers;
using HouseCostMonitor.Application.Services.Expense.Queries.GetExpenses;
using HouseCostMonitor.Domain.Entities;

public class ExpenseProfile : Profile
{
    public ExpenseProfile()
    {
        CreateMap<CreateExpenseCommand, Expense>();
        
        CreateMap<Expense, ExpenseDto>()
            .ForMember(dest => dest.TotalCost, opt => opt.MapFrom<TotalCostResolver>());
    }
}