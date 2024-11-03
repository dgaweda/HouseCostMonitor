namespace HouseCostMonitor.Application.Expense.Profiles;

using AutoMapper;
using HouseCostMonitor.Application.Expense.Commands.CreateExpense;
using HouseCostMonitor.Application.Expense.Dtos;
using HouseCostMonitor.Application.Expense.Profiles.Resolvers;
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