using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Turno")]
    public class Turno
    {
        [Key]
        [Required]

        public int idTurno { get; set; }

        [Required]
        [StringLength(15)]
        public string turno { get; set; }

        public Turno()
        {

        }
    }
}