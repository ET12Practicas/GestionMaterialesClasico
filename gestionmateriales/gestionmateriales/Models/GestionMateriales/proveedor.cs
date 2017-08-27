using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        [Required]
        public int idProveedor { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Required]
        [StringLength(200)]
        public string contacto { get; set; }

        public Proveedor()
        {

        }
    }
}
