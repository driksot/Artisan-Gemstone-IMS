using ArtisanGemstoneIMS.Domain.Common;

namespace ArtisanGemstoneIMS.Application.Contracts.Persistence;

public interface IGenericRepository<T> where T : AuditableEntity
{
    Task<IReadOnlyList<T>> GetAsync();
    Task<T> GetByIdAsync(Guid id);
    Task CreateAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
