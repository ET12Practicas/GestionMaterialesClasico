using System;
using System.Collections.Generic;
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

        [Required]
        public int JefeSeccion_Id { get; set; }

        public virtual Personal jefeSeccion { get; set; }

        [Required]
        public int Responsable_Id { get; set; }

        public virtual Personal responsable { get; set; }

        public virtual ICollection<ItemOT> ItemOT { get; set; }


        public OrdenTrabajo()
        {
            this.ItemOT = new HashSet<ItemOT>();
        }
    }
}