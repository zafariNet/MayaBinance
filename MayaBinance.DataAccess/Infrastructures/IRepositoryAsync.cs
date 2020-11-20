using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace MayaBinance.DataAccess.Infrastructures
{
    public interface IRepositoryAsync<TEntity> : IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> FindAsync(params object[] keyValues);
        Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues);
        Task DeleteAsync(params object[] keyValues);
        Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues);
        //Task<IEnumerable<TEntity>> FilterAsync(
        //    Expression<Func<TEntity, bool>> predicate = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    List<Expression<Func<TEntity, object>>> includes = null,
        //    int? page = null,
        //    int? pageSize = null);
    }
}
