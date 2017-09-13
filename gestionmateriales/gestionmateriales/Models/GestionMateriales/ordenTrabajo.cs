using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("OrdenDeTrabajo")]
    public class OrdenTrabajo
    {
        [Key]
        [Required]
        public int idOrdenTrabajo { get; set; }

        [Required]
        [StringLength(70)]
        public string nombreTrabajo { get; set; }

        [Required]
        [StringLength(7)]
        public string turno { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        public virtual Personal jefeSeccion { get; set; }

        public virtual Personal responsable { get; set; }

        public virtual ICollection<ItemOT> ItemOT { get; set; }


        public OrdenTrabajo()
        {
            this.ItemOT = new HashSet<ItemOT>();
        }
    }
}