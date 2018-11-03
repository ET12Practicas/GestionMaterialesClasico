using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class SalidaMaterialRepository : Repository<SalidaMaterial>, ISalidaMaterialRepository
    {
        public SalidaMaterialRepository(DbContext Context) : base(Context)
        {
        }

        public override IEnumerable<SalidaMaterial> Find(Expression<Func<SalidaMaterial, bool>> predicate = null)
        {
            return context.Set<SalidaMaterial>().Where(predicate)
               .Include(x => x.tipoSalidaMaterial)
               .Include(x => x.material)
               .ToList();
        }
    }
}