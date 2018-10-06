using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public readonly DbContext context;

        public Repository(DbContext Context)
        {
            this.context = Context;
        }

        public virtual void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();
        }

        public virtual void Edit(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public virtual TEntity FindById(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual TEntity FindOne(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate = null)
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        //public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    IQueryable<TEntity> query = context.Set<TEntity>().Where(predicate);

        //    query = includes.Aggregate(query,
        //          (current, include) => current.Include(include));

        //    return query;
        //}

        //public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null)
        //{
        //    IQueryable<TEntity> query = context.Set<TEntity>().Where(predicate);
        //    return include != null ? include(query) : query;
        //}        
    }
}