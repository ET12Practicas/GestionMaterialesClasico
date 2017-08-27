using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Unidad")]
    public class Unidad
    {
        [Key]
        [Required]
        public int idUnidad { get; set; }

        [Required]
        [StringLength(15)]
        public string nombre { get; set; }
    }
}
