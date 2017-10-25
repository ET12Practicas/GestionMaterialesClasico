using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("ItemOP")]

    public class ItemOP
    {
        [Key]
        [Required]
        public int idItemOP { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        public int cantidad { get; set; }

        public ItemOP()
        {
        }
    }
}