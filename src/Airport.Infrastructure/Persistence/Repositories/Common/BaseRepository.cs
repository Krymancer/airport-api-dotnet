using System.Linq.Expressions;
using Airport.Infrastructure.Persistence.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Airport.Infrastructure.Persistence.Repositories.Common;

public abstract class BaseRepository<T> : IBaseRepository<T>
    where T : class
{
    private readonly DbContext _context;
    private readonly DbSet<T> _dbSet;

    public BaseRepository(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public virtual async Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes)
    {
        var query =
            includes.Aggregate<Expression<Func<T, object>>, IQueryable<T>>(_dbSet,
                (current, include) => current.Include(include));

        if (filter is not null) query = query.Where(filter);
        if (orderBy is not null) query = orderBy(query);
        return await query.ToListAsync();
    }
}