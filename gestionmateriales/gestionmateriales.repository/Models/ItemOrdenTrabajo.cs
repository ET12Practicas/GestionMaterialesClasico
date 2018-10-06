using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("itemordentrabajo")]
    public class ItemOrdenTrabajo
    {
        [Key]
        [Required]
        public int idItemOrdenTrabajo { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        public virtual Material material { get; set; }

        [Required]
        public DateTime fechaRetiro { get; set; }

        [Required]
        public virtual OrdenTrabajo ordenTrabajo { get; set; }

        public ItemOrdenTrabajo()
        {

        }
    }
}