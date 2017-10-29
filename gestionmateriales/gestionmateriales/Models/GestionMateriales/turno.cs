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
        [StringLength(7)]
        public string nombre { get; set; }

        public Turno()
        {

        }
    }
}