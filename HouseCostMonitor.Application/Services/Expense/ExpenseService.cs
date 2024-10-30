using HouseCostMonitor.Domain.Repositories;

namespace HouseCostMonitor.Application.Services.Expense;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Exceptions;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Entities;

internal class ExpenseService(IExpenseRepository expenseRepository, IMapper mapper) : IExpenseService
{
    public async Task<IEnumerable<ExpenseDto>> GetAllExpenses(CancellationToken cancellationToken = default)
    {
        return (await expenseRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<ExpenseDto>(mapper.ConfigurationProvider)
            .ToList();
    }

    public async Task<ExpenseDto?> GetExpenseById(Guid id, CancellationToken cancellationToken = default)
    {
        var expense = await expenseRepository.GetByIdAsync(id, cancellationToken);
        if (expense is null)
            throw new ApplicationException("Expense not found");

        return mapper.Map<ExpenseDto>(expense);
    }

    public async Task<Guid> CreateExpense(AddExpenseDto addExpenseDto, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Expense>(addExpenseDto);

        var id = await expenseRepository.AddAsync(expense, cancellationToken);

        return id;
    }

    public async Task RemoveExpense(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Guid> EditExpense(EditExpenseDto editExpenseDto, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}