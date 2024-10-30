namespace HouseCostMonitor.Application.Services.Expense;

using HouseCostMonitor.Application.Services.Expense.Dtos;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> GetAllExpenses(CancellationToken cancellationToken = default);
    Task<ExpenseDto?> GetExpenseById(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateExpense(CreateExpenseDto createExpenseDto, CancellationToken cancellationToken = default);
    Task RemoveExpense(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> EditExpense(EditExpenseDto editExpenseDto, CancellationToken cancellationToken = default);
}