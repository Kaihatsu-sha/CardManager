
namespace Kaihatsu.CardManager.Core.Interfaces;

public interface IRepositoryAsync<T, TId> //FIX : IRepositoryAsync<Card,Guid>
    where T : BaseEntity
    where TId : notnull
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> GetByIdAsync(TId id, CancellationToken cancellationToken = default);
    Task<T?> CreateAsync(T item, CancellationToken cancellationToken = default);
    Task<T?> UpdateAsync(T item, CancellationToken cancellationToken = default);
    Task<T?> DeleteAsync(T item, CancellationToken cancellationToken = default);
}
