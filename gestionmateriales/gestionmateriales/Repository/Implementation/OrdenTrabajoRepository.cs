using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gestionmateriales.Repository.Implementation
{
    public class OrdenTrabajoRepository : Repository<OrdenTrabajo>, IOrdenTrabajoRepository
    {
        public OrdenTrabajoRepository(DbContext Context) : base(Context)
        {
        }
    }
}