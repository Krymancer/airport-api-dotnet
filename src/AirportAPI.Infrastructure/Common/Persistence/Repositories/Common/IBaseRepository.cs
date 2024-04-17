using System.Linq.Expressions;

namespace Infrastructure.Common.Persistence.Repositories.Common;

public interface IBaseRepository<T>
{
    Task<IEnumerable<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, params Expression<Func<T, object>>[] includes);
}