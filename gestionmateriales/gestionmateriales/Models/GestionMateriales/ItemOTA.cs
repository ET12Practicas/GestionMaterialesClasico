using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table ("ItemOT")]

    public class ItemOTA
    {
        [Key]
        [Required]
        public int idItemOTA { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public int idOrdenTrabajoAplicacion { get; set; }

        [Required]
        public OrdenTrabajoAplicacion ordenTrabajoAplicacion { get; set; }

        public ItemOTA()
        {
        }

        public ItemOTA(int idOta, int idMat, int cant)
        {
            this.idItemOTA = idOta;
            this.idMaterial = idMat;
            this.cantidad = cant;
        }

        public ItemOTA(OrdenTrabajoAplicacion aOrden, Material aMaterial, int cant)
        {
            this.ordenTrabajoAplicacion = aOrden;
            this.material = aMaterial;
            this.cantidad = cantidad;
        }
    }
}