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
        public int numero { get; set; }

        [Required]
        public int cantidad { get; set; }

        //[Required]
        //[NotMapped]
        //public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public string destino { get; set; }

        [Required]
        public double precioUnitario { get; set; }

        [Required]
        public double precioParcial { get; set; }

        //[Required]
        //[NotMapped]
        //public int idOrdenCompra { get; set; }

        [Required]
        public OrdenCompra ordenCompra { get; set; }

        public ItemOrdenCompra()
        {

        }
    }
}