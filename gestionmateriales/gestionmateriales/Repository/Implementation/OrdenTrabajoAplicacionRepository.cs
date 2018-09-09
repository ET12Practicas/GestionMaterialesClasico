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
    public class OrdenTrabajoAplicacionRepository : Repository<OrdenTrabajoAplicacion>, IOrdenTrabajoAplicacionRepository
    {
        public OrdenTrabajoAplicacionRepository(DbContext Context) : base(Context)
        {
        }

        public override OrdenTrabajoAplicacion FindById(int id)
        {
            return context.Set<OrdenTrabajoAplicacion>().Where(x => x.idOrdenTrabajoAplicacion == id)
                .Include(x => x.turno)
                .Include(x => x.responsable)
                .Include(x => x.jefeSeccion).ToList().FirstOrDefault();
        }

        public override OrdenTrabajoAplicacion FindOne(Expression<Func<OrdenTrabajoAplicacion, bool>> predicate)
        {
            return context.Set<OrdenTrabajoAplicacion>().Where(predicate)
                .Include(x => x.turno)
                .Include(x => x.responsable)
                .Include(x => x.jefeSeccion)
                .Include(x => x.itemsOTA)
                .ToList().FirstOrDefault();
        }
    }
}