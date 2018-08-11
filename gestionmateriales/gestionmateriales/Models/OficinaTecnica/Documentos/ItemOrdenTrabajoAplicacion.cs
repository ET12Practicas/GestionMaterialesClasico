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
        public int cantidad { get; set; }

        [Required]
        [NotMapped]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        [NotMapped]
        public int idOrdenTrabajoAplicacion { get; set; }

        [Required]
        public OrdenTrabajoAplicacion ordenTrabajoAplicacion { get; set; }

        public ItemOrdenTrabajoAplicacion()
        {

        }
    }
}