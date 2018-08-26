using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class EntradaMaterialRepository : Repository<EntradaMaterial>, IEntradaMaterialRepository
    {
        public EntradaMaterialRepository(DbContext Context) : base(Context)
        {
        }
    }
}