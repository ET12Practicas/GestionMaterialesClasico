using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("TipoSalida")]
    public class TipoSalida
    {
        [Key]
        [Required]
        public int idTipoSalida { get; set; }

        [Required]
        [StringLength(35)]
        public string nombre { get; set; }

        [Required]
        public int idSector { get; set; }

        public TipoSalida()
        {

        }
    }
}