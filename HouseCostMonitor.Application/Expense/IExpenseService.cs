namespace HouseCostMonitor.Application.Expense;

public interface IExpenseService
{
    Task<IEnumerable<Domain.Entities.Expense>> GetAllExpenses();
}