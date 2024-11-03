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
    
    public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default)
    {
        if(filter == null)
            return await _entity.ToListAsync(cancellationToken: cancellationToken);

        return await _entity.Where(filter).ToListAsync(cancellationToken: cancellationToken);
    }

    public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _entity.FirstOrDefaultAsync(x => x.Id == id, cancellationToken: cancellationToken);
    }
    
    public async Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
    {
        return await _entity.FirstOrDefaultAsync(filter, cancellationToken: cancellationToken);
    }

    public async Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default)
    {
        await _entity.AddAsync(entity, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }

    public async Task AddManyAsync(List<T> entities, CancellationToken cancellationToken = default)
    {
        if (entities.IsNullOrEmpty())
            throw new RepositoryException("Can't add empty list");
        
        await _entity.AddRangeAsync(entities, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Guid?> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var deletedRows = await _entity.Where(x => x.Id == id).ExecuteDeleteAsync(cancellationToken: cancellationToken);
        if (deletedRows > 0)
            return id;

        return null;
    }

    public async Task<Guid> UpdateAsync(T entity, CancellationToken cancellationToken = default)
    {
        _entity.Attach(entity);
        dbContext.Entry(_entity).State = EntityState.Modified;
        await dbContext.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}