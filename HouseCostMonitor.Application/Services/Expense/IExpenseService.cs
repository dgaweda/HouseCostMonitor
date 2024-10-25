namespace HouseCostMonitor.Application.Services.Expense;

public interface IExpenseService
{
    Task<IEnumerable<Domain.Entities.Expense>> GetAllExpenses();
}