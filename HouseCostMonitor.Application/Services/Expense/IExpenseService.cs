namespace HouseCostMonitor.Application.Services.Expense;

using HouseCostMonitor.Application.Services.Expense.Dtos;

public interface IExpenseService
{
    Task<IEnumerable<ExpenseDto>> GetAllExpenses(CancellationToken cancellationToken = default);
}