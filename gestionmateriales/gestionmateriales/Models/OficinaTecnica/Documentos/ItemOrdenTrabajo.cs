using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ItemOrdenTrabajo")]
    public class ItemOrdenTrabajo
    {
        [Key]
        [Required]
        public int idItemOrdenTrabajo { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        [NotMapped]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        [NotMapped]
        public int idOrdenTrabajo{ get; set; }

        [Required]
        public OrdenTrabajo ordenTrabajo { get; set; }

        public ItemOrdenTrabajo()
        {

        }
    }
}