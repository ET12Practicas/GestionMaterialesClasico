using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace gestionmateriales.Repository.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();

        TEntity GetById(int Id);

        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        //IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null);

        void Add(TEntity entity);

        void Edit(TEntity entity);

        void Remove(TEntity entity);
    }
}
