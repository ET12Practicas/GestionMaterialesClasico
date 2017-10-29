using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table ("ItemOT")]

    public class ItemOT
    {
        [Key]
        [Required]
        public int idItemOT { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public int idOrdenTrabajo { get; set; }

        [Required]
        public OrdenTrabajo ordenTrabajo { get; set; }

        public ItemOT()
        {
        }

        public ItemOT(int idOt, int idMat, int cant)
        {
            this.idItemOT = idOt;
            this.idMaterial = idMat;
            this.cantidad = cant;
        }

        public ItemOT(OrdenTrabajo aOrden, Material aMaterial, int cant)
        {
            this.ordenTrabajo = aOrden;
            this.material = aMaterial;
            this.cantidad = cantidad;
        }
    }
}