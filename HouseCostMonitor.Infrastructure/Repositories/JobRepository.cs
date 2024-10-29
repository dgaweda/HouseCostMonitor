namespace HouseCostMonitor.Infrastructure.Repositories;

using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;
using HouseCostMonitor.Infrastructure.Repositories.Base;

internal class JobRepository(HouseCostMonitorDbContext dbContext) : BaseRepository<Job>(dbContext), IJobRepository
{
    
}