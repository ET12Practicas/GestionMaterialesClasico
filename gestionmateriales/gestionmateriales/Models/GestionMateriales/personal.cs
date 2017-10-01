using System;
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
        [StringLength(60)]
        public string nombre { get; set; }

        public int dni { get; set; }

        [Required]
        public int fichaCensal { get; set; }

        [Required]
        public bool habilitado { get; set; }

        public Personal()
        {
            this.habilitado = true;
        }
    }
}
