using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Tipos
{
    [Table("TipoSalidaMaterial")]
    public class TipoSalidaMaterial
    {
        [Key]
        [Required]
        public int idTipoSalidaMaterial { get; set; }

        [Required]
        [StringLength(35)]
        public string nombre { get; set; }

        [Required]
        public int idSector { get; set; }

        public TipoSalidaMaterial()
        {

        }
    }
}