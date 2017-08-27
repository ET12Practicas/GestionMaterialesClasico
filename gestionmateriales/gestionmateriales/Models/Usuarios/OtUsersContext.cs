using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;

namespace gestionmateriales.Models.Usuarios
{
    public class OtUsersContext : DbContext
    {
        public OtUsersContext() : base("OtUsersEntities")
        {

        }

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Rol> Rol { get; set; }
    }
}