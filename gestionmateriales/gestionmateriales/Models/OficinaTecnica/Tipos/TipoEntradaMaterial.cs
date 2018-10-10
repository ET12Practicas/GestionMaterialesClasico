using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Tipos
{
    [Table("TipoEntradaMaterial")]
    public class TipoEntradaMaterial
    {
        [Key]
        [Required]
        public int idTipoEntradaMaterial { get; set; }

        [Required]
        [StringLength(35)]
        public string nombre { get; set; }

        [Required]
        public int idSector { get; set; }

        public TipoEntradaMaterial()
        {

        }
    }
}