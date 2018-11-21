using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ItemOrdenTrabajoAplicacion")]
    public class ItemOrdenTrabajoAplicacion
    {
        [Key]
        [Required]
        public int idItemOrdenTrabajoAplicacion { get; set; }

        [Required]
        [StringLength(50)]
        public string destino { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public virtual Material material { get; set; }

        [Required]
        public virtual OrdenTrabajoAplicacion ordenTrabajoAplicacion { get; set; }

        public ItemOrdenTrabajoAplicacion()
        {

        }
    }
}