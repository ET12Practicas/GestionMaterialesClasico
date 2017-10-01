using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("OrdenTrabajo")]
    public class OrdenTrabajo
    {
        [Key]
        [Required]
        public int idOrdenTrabajo { get; set; }

        [Required]
        public int nroOrdenTrabajo { get; set; }

        [Required]
        [StringLength(70)]
        public string nombreTrabajo { get; set; }

        [Required]
        public int Turno_Id { get; set; }
        
        public virtual Turno Turno { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public int JefeSeccion_Id { get; set; }

        public virtual Personal JefeSeccion { get; set; }

        [Required]
        public int Responsable_Id { get; set; }

        public virtual Personal Responsable { get; set; }

        public virtual ICollection<ItemOT> ItemOT { get; set; }

        public OrdenTrabajo()
        {
            this.ItemOT = new HashSet<ItemOT>();
        }

        public OrdenTrabajo(int aNro, string aNombreTrabajo, Turno aTurno, DateTime aFecha, Personal aJefeSeccion, Personal aResponable)
        {
            this.nroOrdenTrabajo = aNro;
            this.nombreTrabajo = aNombreTrabajo;
            this.fecha = aFecha;

            this.Turno_Id = aTurno.idTurno;
            this.Turno = aTurno;

            this.JefeSeccion_Id = aJefeSeccion.idPersonal;
            this.JefeSeccion = aJefeSeccion;
            this.Responsable_Id = aResponable.idPersonal;
            this.Responsable = aResponable;
        }
    }
}