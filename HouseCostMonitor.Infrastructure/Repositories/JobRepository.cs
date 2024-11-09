namespace HouseCostMonitor.Infrastructure.Repositories;

using System.Linq.Expressions;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;
using HouseCostMonitor.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

internal class JobRepository(HouseCostMonitorDbContext dbContext) : BaseRepository<Job>(dbContext), IJobRepository
{
    public override async Task<IEnumerable<Job>> GetAllAsync(Expression<Func<Job, bool>>? filter = null, CancellationToken cancellationToken = default)
    {
        if (filter is null)
            return await dbContext.Jobs.Include(x => x.Expenses).ToListAsync(cancellationToken);
        
        return await dbContext.Jobs.Include(x => x.Expenses).Where(filter).ToListAsync(cancellationToken);
    }
}