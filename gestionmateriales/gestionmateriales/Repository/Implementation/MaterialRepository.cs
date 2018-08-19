using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class MaterialRepository : Repository<Material>, IMaterialRepository
    {
        public MaterialRepository(DbContext Context) : base(Context)
        {
        }
    }
}