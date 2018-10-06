using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Tipos
{
    [Table("unidad")]
    public class Unidad
    {
        [Key]
        [Required]
        public int idUnidad { get; set; }

        [Required]
        [StringLength(15)]
        public string nombre { get; set; }

        public Unidad()
        {

        }
    }
}
