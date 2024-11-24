namespace HouseCostMonitor.Infrastructure.Repositories;

using System.Linq.Expressions;
using HouseCostMonitor.Domain.Entities;
using HouseCostMonitor.Domain.Exceptions;
using HouseCostMonitor.Domain.Repositories;
using HouseCostMonitor.Infrastructure.Persistence;
using HouseCostMonitor.Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

internal class HouseRepository(HouseCostMonitorDbContext dbContext) : BaseRepository<House>(dbContext), IHouseRepository
{
    public override async Task<IEnumerable<House>> GetAllAsync(Expression<Func<House, bool>>? filter = null, CancellationToken cancellationToken = default)
    {
        if (filter is null)
            return await dbContext.Houses
                .Include(x => x.Jobs)
                .ThenInclude(x => x.Expenses)
                .ToListAsync(cancellationToken);
        
        return await dbContext.Houses
            .Include(x => x.Jobs)
            .ThenInclude(x => x.Expenses)
            .Where(filter)
            .ToListAsync(cancellationToken);
    }
    
    public override async Task<House> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var house = await dbContext.Houses
            .Include(x => x.Jobs)
            .ThenInclude(x => x.Expenses)
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
        
        if (house is null)
            throw new NotFoundException(nameof(House));

        return house;
    }
}