using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using LinqKit;
using MayaBinance.DataAccess.Context;
using MayaBinance.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;

namespace MayaBinance.DataAccess.Infrastructures
{
    public class Repository<TEntity> : IRepositoryAsync<TEntity> where TEntity : class
    {
        #region Private Fields

        private readonly DbSet<TEntity> _dbSet;

        public IUnitOfWork UnitOfWork { get; set; }

        #endregion Private Fields

        public Repository(MayaBinanceContext context)
        {
            UnitOfWork = context ?? throw new ArgumentNullException(nameof(context));
         
                _dbSet = context.Set<TEntity>();
            
        }
        public virtual TEntity Find(params object[] keyValues) => _dbSet.Find(keyValues);

        public TEntity Find(Expression<Func<TEntity, bool>> predicate) => _dbSet.FirstOrDefault(predicate);

        public TEntity Find<TKey>(Expression<Func<TEntity, TKey>> sortExpression, bool isDesc, Expression<Func<TEntity, bool>> predicate) => isDesc ? _dbSet.OrderBy(sortExpression).FirstOrDefault(predicate) : _dbSet.OrderByDescending(sortExpression).FirstOrDefault(predicate);

        public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters) => _dbSet.FromSqlRaw(query, parameters).AsQueryable();

        public virtual void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Insert(entity);
            }
        }

        public virtual void Update(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            var entity = _dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IQueryable<TEntity> GetAll() => _dbSet;

        public IQueryFluent<TEntity> Query() => new QueryFluent<TEntity>(this);

        public virtual IQueryFluent<TEntity> Query(IQueryObject<TEntity> queryObject) => new QueryFluent<TEntity>(this, queryObject);

        public virtual IQueryFluent<TEntity> Query(Expression<Func<TEntity, bool>> query) => new QueryFluent<TEntity>(this, query);

        public IQueryable<TEntity> Queryable() => _dbSet;


        public virtual async Task<TEntity> FindAsync(params object[] keyValues) => await _dbSet.FindAsync(keyValues);

        public virtual async Task<TEntity> FindAsync(CancellationToken cancellationToken, params object[] keyValues) => await _dbSet.FindAsync(cancellationToken, keyValues);

        public virtual async Task DeleteAsync(params object[] keyValues) => await DeleteAsync(CancellationToken.None, keyValues);

        public virtual async Task DeleteAsync(CancellationToken cancellationToken, params object[] keyValues)
        {
            var entity = await FindAsync(cancellationToken, keyValues);


            _dbSet.Remove(entity);
        }

        internal IQueryable<TEntity> Select(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }

        internal async Task<IEnumerable<TEntity>> SelectAsync(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            return await Select(predicate, orderBy, includes, page, pageSize).ToListAsync();
        }

        public virtual IQueryable<TEntity> Filter(
            Expression<Func<TEntity, bool>> predicate = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            List<Expression<Func<TEntity, object>>> includes = null,
            int? page = null,
            int? pageSize = null)
        {
            IQueryable<TEntity> query = _dbSet;

            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            if (predicate != null)
            {
                query = query.AsExpandable().Where(predicate);
            }
            if (page != null && pageSize != null)
            {
                query = query.Skip((page.Value - 1) * pageSize.Value).Take(pageSize.Value);
            }
            return query;
        }

        //public virtual async Task<IEnumerable<TEntity>> FilterAsync(
        //    Expression<Func<TEntity, bool>> predicate = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    List<Expression<Func<TEntity, object>>> includes = null,
        //    int? page = null,
        //    int? pageSize = null)
        //{
        //    var select = Select(predicate, orderBy, includes, page, pageSize);
        //    var result= await select.ToListAsync();
        //    return result;
        //}
    }
}
