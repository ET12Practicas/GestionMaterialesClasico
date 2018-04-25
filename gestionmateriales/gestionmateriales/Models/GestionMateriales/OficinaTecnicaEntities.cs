using AspNet.Identity.MySQL;
using System.Data.Entity;

namespace gestionmateriales.Models.GestionMateriales
{
    public class OficinaTecnicaEntities : DbContext//MySQLDatabase
    {
        public OficinaTecnicaEntities()
            : base("OtEntities")
        {

        }

        public DbSet<Proveedor> proveedores { get; set; }

        public DbSet<Unidad> unidades { get; set; }

        public DbSet<Material> materiales { get; set; }

        public DbSet<Entrada> entradas { get; set; }

        public DbSet<Salida> salidas { get; set; }

        public DbSet<Personal> personal { get; set; }

        public DbSet<OrdenTrabajoAplicacion> ordenTrabajoAplicacion { get; set; }

        public DbSet<OrdenPedido> ordenPedido { get; set; }

        public DbSet<TipoMaterial> tipoMaterial { get; set; }

        public DbSet<TipoEntrada> tipoEntrada { get; set; }

        public DbSet<TipoSalida> tipoSalida { get; set; }

        public DbSet<Turno> turnos { get; set; }

        public DbSet<ItemOTA> ItemOTA { get; set; }

        public DbSet<ItemOP> ItemOP { get; set; }
    }
}
