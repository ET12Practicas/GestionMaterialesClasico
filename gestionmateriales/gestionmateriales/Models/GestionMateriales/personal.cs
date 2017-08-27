using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Personal")]
    public class Personal
    {
        [Key]
        [Required]
        public int idPersonal { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Required]
        [StringLength(45)]
        public string apellido { get; set; }

        public Nullable<int> dni { get; set; }

        [Required]
        public int fichaCensal { get; set; }

        public Personal()
        {

        }
    }
}
