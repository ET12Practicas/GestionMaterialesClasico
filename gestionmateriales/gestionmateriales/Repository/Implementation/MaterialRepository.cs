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
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(DbContext Context) : base(Context)
        {
        }

        public override Material FindOne(Expression<Func<Material, bool>> predicate = null)
        {
            return context.Set<Material>().Where(predicate)
               .Include(x => x.tipoMaterial)
               .Include(x => x.proveedor)
               .Include(x => x.unidad)
               .Include(x => x.entradas)
               .Include(x => x.salidas)
               .ToList()
               .FirstOrDefault();
        }

        public override Material FindById(int id)
        {
            return context.Set<Material>().Where(x => x.idMaterial == id)
                .Include(x => x.tipoMaterial)
                .Include(x => x.proveedor)
                .Include(x => x.unidad).ToList().FirstOrDefault();
        }

        public override IEnumerable<Material> Find(Expression<Func<Material, bool>> predicate = null)
        {
            return context.Set<Material>().Where(predicate)
                .Include(x => x.tipoMaterial)
                .Include(x => x.proveedor)
                .Include(x => x.unidad).ToList();
        }
    }
}