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
        [StringLength(30)]
        public string responsable { get; set; }

        [Required]
        [StringLength(7)]
        public string turno { get; set; }

        [Required]
        [StringLength(30)]
        public string jefeSeccion { get; set; }


        public virtual ICollection<ItemOT> ItemOT { get; set; }


        public OrdenTrabajo()
        {
            this.ItemOT = new HashSet<ItemOT>();
        }
    }
}