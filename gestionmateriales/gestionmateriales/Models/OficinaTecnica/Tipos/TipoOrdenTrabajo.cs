using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Tipos
{
    [Table("TipoOrdenTrabajo")]
    public class TipoOrdenTrabajo
    {
        [Key]
        [Required]        
        public int idTipoOrdenTrabajo { get; set; }

        [Required]
        [StringLength(30)]
        public string nombre { get; set; }

        public TipoOrdenTrabajo()
        {

        }
    }
}