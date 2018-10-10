using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Tipos
{
    [Table("TipoMaterial")]
    public class TipoMaterial
    {
        [Key]
        [Required]
        public int idTipoMaterial { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }

        public TipoMaterial()
        {

        }
    }
}