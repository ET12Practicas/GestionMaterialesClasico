using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ItemRemito")]
    public class ItemRemito
    {
        [Key]
        [Required]
        public int IdItemRemito { get; set; }

        [Required]
        public int nroItem { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public double precioUnitario { get; set; }

        [Required]
        public double importe { get; set; }

        [Required]
        public virtual Remito remito { get; set; }

        public ItemRemito()
        {

        }
    }
}