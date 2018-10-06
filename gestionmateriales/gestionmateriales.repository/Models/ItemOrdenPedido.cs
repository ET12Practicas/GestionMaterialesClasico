using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("itemordenpedido")]
    public class ItemOrdenPedido
    {
        [Key]
        [Required]
        public int idItemOrdenPedido { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        [NotMapped]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        [NotMapped]
        public int idOrdenPedido { get; set; }

        [Required]
        public OrdenPedido ordenPedido { get; set; }

        public ItemOrdenPedido()
        {

        }
    }
}