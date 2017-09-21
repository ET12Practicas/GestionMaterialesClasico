using System.Data.Entity;

namespace gestionmateriales.Models.GestionMateriales
{
    public class OtContext : DbContext
    {
        public OtContext()
            : base("OtEntities")
        {

        }

        public DbSet<Proveedor> Proveedor { get; set; }

        public DbSet<Unidad> Unidad { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<Material> Material { get; set; }

        public DbSet<Entrada> Entrada { get; set; }

        public DbSet<Salida> Salida { get; set; }

        public DbSet<Personal> Personal { get; set; }

        public DbSet<OrdenTrabajo> OrdenTrabajo { get; set; }

        public DbSet<TipoMaterial> TipoMaterial { get; set; }

        public DbSet<Turno> Turno { get; set; }
    }
}
