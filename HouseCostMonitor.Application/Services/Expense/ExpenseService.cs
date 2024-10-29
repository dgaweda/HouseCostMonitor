using HouseCostMonitor.Domain.Repositories;

namespace HouseCostMonitor.Application.Services.Expense;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Services.Expense.Dtos;

internal class ExpenseService(IExpenseRepository expenseRepository, IMapper mapper) : IExpenseService
{
    public async Task<IEnumerable<ExpenseDto>> GetAllExpenses(CancellationToken cancellationToken = default)
    {
        return (await expenseRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<ExpenseDto>(mapper.ConfigurationProvider)
            .ToList();
    }
}