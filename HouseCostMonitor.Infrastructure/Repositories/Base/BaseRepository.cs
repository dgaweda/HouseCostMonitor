namespace HouseCostMonitor.Infrastructure.Repositories.Base;

using System.Linq.Expressions;
using HouseCostMonitor.Domain.Entities.Base;
using HouseCostMonitor.Domain.Repositories.Base;
using HouseCostMonitor.Infrastructure.Exceptions;
using HouseCostMonitor.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

internal class BaseRepository<T>(HouseCostMonitorDbContext dbContext) : IBaseRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _entity = dbContext.Set<T>();
    
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null)
    {
        if(filter == null)
            return await _entity.ToListAsync();

        return await _entity.Where(filter).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _entity.FirstOrDefaultAsync(x => x.Id == id);
    }
    
    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
    {
        return await _entity.FirstOrDefaultAsync(filter);
    }

    public async Task AddAsync(T entity)
    {
        await _entity.AddAsync(entity);
        await dbContext.SaveChangesAsync();
    }

    public async Task AddManyAsync(List<T> entities)
    {
        if (entities.IsNullOrEmpty())
            throw new RepositoryException("Can't add empty list");
        
        await _entity.AddRangeAsync(entities);
        await dbContext.SaveChangesAsync();
    }

    public async Task<Guid> DeleteAsync(Guid id)
    {
        await _entity.Where(x => x.Id == id).ExecuteDeleteAsync();

        return id;
    }

    public async Task<Guid> UpdateAsync(T entity)
    {
        _entity.Attach(entity);
        dbContext.Entry(_entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }
}