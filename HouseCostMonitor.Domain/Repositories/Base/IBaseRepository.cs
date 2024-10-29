namespace HouseCostMonitor.Domain.Repositories.Base;

using System.Linq.Expressions;
using HouseCostMonitor.Domain.Entities.Base;

public interface IBaseRepository<T> where T : BaseEntity
{
    Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>>? filter = null);
    Task<T?> GetByIdAsync(Guid id);
    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task AddAsync(T entity);
    Task AddManyAsync(List<T> entities);
    Task<Guid> DeleteAsync(Guid id);
    Task<Guid> UpdateAsync(T entity);
}