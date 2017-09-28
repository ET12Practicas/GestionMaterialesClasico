using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("TipoEntrada")]
    public class TipoEntrada
    {
        [Key]
        [Required]
        public int idTipoEntrada { get; set; }

        [Required]
        [StringLength(35)]
        public string nombre { get; set; }

        public TipoEntrada()
        {

        }
    }
}