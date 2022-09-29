using Kaihatsu.CardManager.Core.Interfaces;
using Kaihatsu.CardManager.Core;
using Microsoft.EntityFrameworkCore;

namespace Kaihatsu.CardManager.DAL.Repository;

public abstract class RepositoryBaseAsync<T> : IRepositoryAsync<T, Guid>
    where T : BaseEntity
{
    protected readonly DbContext _context;

    public RepositoryBaseAsync(DbContext context)
    {
        _context = context;
    }

    public virtual async Task<T?> CreateAsync(T item, CancellationToken cancellationToken = default)
    {
        await _context
            .Set<T>()
            .AddAsync(item, cancellationToken)
            .ConfigureAwait(false);

        await _context
            .SaveChangesAsync()
            .ConfigureAwait(false);

        return item;
    }

    public virtual async Task<T?> DeleteAsync(T item, CancellationToken cancellationToken = default)
    {
        if (!await _context.Set<T>().AnyAsync(i => i.Id == item.Id, cancellationToken).ConfigureAwait(false))
            return null;

        _context.Entry(item).State = EntityState.Deleted;
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return item;
    }

    public virtual async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        var items = await _context
           .Set<T>()
           .ToArrayAsync(cancellationToken)
           .ConfigureAwait(false);

        return items;
    }

    public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await _context
            .Set<T>()
            .FirstOrDefaultAsync(item => item.Id == id, cancellationToken)
            .ConfigureAwait(false);

        return item;
    }

    public virtual async Task<T?> UpdateAsync(T item, CancellationToken cancellationToken = default)
    {
        if (!await _context.Set<T>().AnyAsync(i => i.Id == item.Id, cancellationToken).ConfigureAwait(false))
            return null;

        _context.Set<T>().Update(item);
        await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        return item;
    }
}
