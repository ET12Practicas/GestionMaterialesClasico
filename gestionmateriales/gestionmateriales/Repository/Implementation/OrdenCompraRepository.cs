using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class OrdenCompraRepository : Repository<OrdenCompra>, IOrdenCompraRepository
    {
        public OrdenCompraRepository(DbContext Context) : base(Context)
        {
        }

        public override OrdenCompra FindById(int id)
        {
            return context.Set<OrdenCompra>().Where(x => x.IdOrdenCompra == id)
                .Include(x => x.proveedor)
                .Include(x => x.responsable)
                .Include(x => x.itemsOC)
                .FirstOrDefault();
        }

        public override OrdenCompra FindOne(Expression<Func<OrdenCompra, bool>> predicate)
        {
            return context.Set<OrdenCompra>().Where(predicate)
                .Include(x => x.proveedor)
                .Include(x => x.responsable)
                .Include(x => x.itemsOC)
                .ToList()
                .FirstOrDefault();
        }
    }
}