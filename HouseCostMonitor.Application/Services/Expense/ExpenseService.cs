using HouseCostMonitor.Domain.Repositories;

namespace HouseCostMonitor.Application.Services.Expense;

using AutoMapper;
using AutoMapper.QueryableExtensions;
using HouseCostMonitor.Application.Exceptions;
using HouseCostMonitor.Application.Services.Expense.Dtos;
using HouseCostMonitor.Domain.Entities;

internal class ExpenseService(IExpenseRepository expenseRepository, IMapper mapper) : IExpenseService
{
    public async Task<IEnumerable<GetExpenseQuery>> GetAllExpenses(CancellationToken cancellationToken = default)
    {
        return (await expenseRepository.GetAllAsync(cancellationToken: cancellationToken))
            .AsQueryable()
            .ProjectTo<GetExpenseQuery>(mapper.ConfigurationProvider)
            .ToList();
    }

    public async Task<GetExpenseQuery?> GetExpenseById(Guid id, CancellationToken cancellationToken = default)
    {
        var expense = await expenseRepository.GetByIdAsync(id, cancellationToken);
        if (expense is null)
            throw new ApplicationException("Expense not found");

        return mapper.Map<GetExpenseQuery>(expense);
    }

    public async Task<Guid> CreateExpense(CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken)
    {
        var expense = mapper.Map<Expense>(createExpenseCommand);
        var id = await expenseRepository.AddAsync(expense, cancellationToken);

        return id;
    }

    public async Task RemoveExpense(Guid id, CancellationToken cancellationToken = default)
    {
        await expenseRepository.DeleteAsync(id, cancellationToken);
    }

    public async Task<Guid> EditExpense(Guid expenseId, EditExpenseCommand editExpenseCommand, CancellationToken cancellationToken = default)
    {
        editExpenseCommand.Id = expenseId;
        var expense = mapper.Map<Expense>(editExpenseCommand);
        var id = await expenseRepository.UpdateAsync(expense, cancellationToken);

        return id;
    }
}