using gestionmateriales.Models.OficinaTecnica.Documentos;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;
using System.Data.Entity;

namespace gestionmateriales.Models.OficinaTecnica
{
    public class OficinaTecnicaEntities : DbContext
    {
        public OficinaTecnicaEntities()
            : base("OtEntities")
        {
        }

        public DbSet<Proveedor> proveedores { get; set; }

        public DbSet<Unidad> unidades { get; set; }

        public DbSet<Material> materiales { get; set; }

        public DbSet<EntradaMaterial> entradas { get; set; }

        public DbSet<SalidaMaterial> salidas { get; set; }

        public DbSet<Personal> personal { get; set; }

        public DbSet<OrdenTrabajoAplicacion> ordenTrabajoAplicacion { get; set; }

        public DbSet<OrdenTrabajo> ordenTrabajo { get; set; }

        public DbSet<OrdenPedido> ordenPedido { get; set; }

        public DbSet<OrdenCompra> ordenCompra { get; set; }

        public DbSet<TipoOrdenTrabajo> tipoOrdenTrabajo { get; set; }

        public DbSet<TipoMaterial> tipoMaterial { get; set; }

        public DbSet<TipoEntradaMaterial> tipoEntrada { get; set; }

        public DbSet<TipoSalidaMaterial> tipoSalida { get; set; }

        public DbSet<Turno> turnos { get; set; }

        public DbSet<ItemOrdenTrabajoAplicacion> ItemOTA { get; set; }

        public DbSet<ItemOrdenTrabajo> ItemOT { get; set; }

        public DbSet<ItemOrdenPedido> ItemOP { get; set; }

        public DbSet<ItemOrdenCompra> ItemOC { get; set; }
    }
}
