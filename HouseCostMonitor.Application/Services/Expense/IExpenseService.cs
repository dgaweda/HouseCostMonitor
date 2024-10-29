namespace HouseCostMonitor.Application.Services.Expense;

using HouseCostMonitor.Application.Services.Expense.Dtos;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> GetAllExpenses(CancellationToken cancellationToken = default);
    Task<ExpenseDto?> GetExpenseById(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> CreateExpense(AddExpenseDto addExpenseDto, CancellationToken cancellationToken);
}