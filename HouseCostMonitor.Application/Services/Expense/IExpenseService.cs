namespace HouseCostMonitor.Application.Services.Expense;

using HouseCostMonitor.Application.Services.Expense.Dtos;

public interface IExpenseService
{
    Task<IEnumerable<GetExpenseQuery>> GetAllExpenses(CancellationToken cancellationToken = default);
    Task<GetExpenseQuery?> GetExpenseById(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateExpense(CreateExpenseCommand createExpenseCommand, CancellationToken cancellationToken = default);
    Task RemoveExpense(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> EditExpense(Guid expenseId, EditExpenseCommand editExpenseCommand, CancellationToken cancellationToken = default);
}