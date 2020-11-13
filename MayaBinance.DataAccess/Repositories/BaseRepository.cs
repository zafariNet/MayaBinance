using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using MayaBinance.DataAccess.Context;
using MayaBinance.Domain;
using MayaBinance.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;


namespace MayaBinance.DataAccess.Repositories
{
    public class BaseRepository<TKey,TEntity> : IBaseRepository<TKey,TEntity> where TEntity : class
    {
        internal MayaBinanceContext Context;
        internal DbSet<TEntity> DbSet;
        public IUnitOfWork UnitOfWork => Context;

        public BaseRepository(MayaBinanceContext context)
        {
            Context = context;
            DbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> GetWithRawSql(string query,
            params object[] parameters)
        {
            return DbSet.FromSqlRaw(query, parameters).ToList();
        }

        public virtual IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                for (var index = 0;
                    index < includeProperties.Split
                        (new char[] {','}, StringSplitOptions.RemoveEmptyEntries).Length;
                    index++)
                {
                    var includeProperty = includeProperties.Split
                        (new char[] {','}, StringSplitOptions.RemoveEmptyEntries)[index];
                    query = query.Include(includeProperty);
                }
            }


            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return DbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual void Delete(TKey id)
        {
            TEntity entityToDelete = DbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (Context.Entry(entityToDelete).State == EntityState.Detached)
            {
                DbSet.Attach(entityToDelete);
            }
            DbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            DbSet.Attach(entityToUpdate);
            Context.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
