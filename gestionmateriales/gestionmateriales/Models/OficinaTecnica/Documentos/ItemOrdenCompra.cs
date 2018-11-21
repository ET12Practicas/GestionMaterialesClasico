using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ItemOrdenCompra")]
    public class ItemOrdenCompra
    {
        [Key]
        [Required]
        public int idItemOrdenCompra { get; set; }

        [Required]
        public virtual Material material { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public double precioUnitario { get; set; }

        [Required]
        public double subtotal { get; set; }

        [Required]
        public virtual OrdenCompra ordenCompra { get; set; }

        public ItemOrdenCompra()
        {

        }
    }
}