using HouseCostMonitor.Domain.Entities;

namespace HouseCostMonitor.Domain.Repositories;

public interface IExpenseRepository
{
    Task<IEnumerable<Expense>> GetAllAsync();
}