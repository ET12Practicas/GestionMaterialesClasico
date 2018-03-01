using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("ItemOP")]

    public class ItemOP
    {
        [Key]
        [Required]
        public int idItemOP { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public int idOrdenPedido { get; set; }

        [Required]
        public OrdenPedido ordenPedido { get; set; }

        public ItemOP()
        {
        }

        public ItemOP(int idOt, int idMat, int cant)
        {
            this.idItemOP = idOt;
            this.idMaterial = idMat;
            this.cantidad = cant;
        }
    }
}