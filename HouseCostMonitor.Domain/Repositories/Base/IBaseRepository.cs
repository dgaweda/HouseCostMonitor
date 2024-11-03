namespace HouseCostMonitor.Domain.Repositories.Base;

using System.Linq.Expressions;
using HouseCostMonitor.Domain.Entities.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null, CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default);
    Task<Guid> AddAsync(T entity, CancellationToken cancellationToken = default);
    Task AddManyAsync(List<T> entities, CancellationToken cancellationToken = default);
    Task<Guid?> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Guid> UpdateAsync(T entity, CancellationToken cancellationToken = default);
}