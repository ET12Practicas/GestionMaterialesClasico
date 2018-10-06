using gestionmateriales.Models.OficinaTecnica.Tipos;
using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class TipoEntradaMaterialRepository : Repository<TipoEntradaMaterial>, ITipoEntradaMaterialRepository
    {
        public TipoEntradaMaterialRepository(DbContext Context) : base(Context)
        {
        }
    }
}