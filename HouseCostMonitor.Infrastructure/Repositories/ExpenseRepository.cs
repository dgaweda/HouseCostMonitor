using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;

namespace HouseCostMonitor.Infrastructure.Repositories;

using HouseCostMonitor.Infrastructure.Repositories.Base;

internal class ExpenseRepository(HouseCostMonitorDbContext dbContext) : BaseRepository<Expense>(dbContext), IExpenseRepository
{
    
}