using gestionmateriales.Models.OficinaTecnica.Documentos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    [Table("ItemOrdenTrabajoAplicacion")]
    public class ItemOrdenTrabajoAplicacion
    {
        [Key]
        [Required]
        public int idItemOrdenTrabajoAplicacion { get; set; }

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

        public ItemOrdenTrabajoAplicacion()
        {
        }

        public ItemOrdenTrabajoAplicacion(int idOta, int idMat, int cant)
        {
            this.idItemOrdenTrabajoAplicacion = idOta;
            this.idMaterial = idMat;
            this.cantidad = cant;
        }

        public ItemOrdenTrabajoAplicacion(OrdenTrabajoAplicacion aOrden, Material aMaterial, int cant)
        {
            this.ordenTrabajoAplicacion = aOrden;
            this.material = aMaterial;
            this.cantidad = cantidad;
        }
    }
}