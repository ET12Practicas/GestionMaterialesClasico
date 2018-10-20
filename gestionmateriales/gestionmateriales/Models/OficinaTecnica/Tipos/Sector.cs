using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Tipos
{
    [Table("Sector")]
    public class Sector
    {
        [Key]
        [Required]
        public int idSector { get; set; }

        [Required]
        [StringLength(50)]
        public string nombre { get; set; }

        public Sector()
        {
                
        }
    }
}