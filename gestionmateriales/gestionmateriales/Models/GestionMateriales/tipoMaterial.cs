using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("TipoMaterial")]
    public class TipoMaterial
    {
        [Key]
        [Required]
        public int idTipoMaterial { get; set; }

        [Required]
        [StringLength(20)]
        public string nombre { get; set; }

        public TipoMaterial()
        {

        }
    }
}