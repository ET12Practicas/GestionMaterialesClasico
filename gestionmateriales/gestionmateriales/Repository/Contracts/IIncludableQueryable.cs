using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestionmateriales.Repository.Contracts
{
    public interface IIncludableQueryable<out TEntity, out TProperty> : IQueryable<TEntity>, IEnumerable<TEntity>, IEnumerable, IQueryable
    {
    }
}
