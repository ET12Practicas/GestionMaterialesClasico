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
        public int numero { get; set; }

        [Required]
        [StringLength(70)]
        public string nombre { get; set; }

        [Required]
        public int idTurno { get; set; }
        
        public virtual Turno Turno { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public int idJefeSeccion { get; set; }

        public virtual Personal jefeSeccion { get; set; }

        [Required]
        public int idResponsable { get; set; }

        public virtual Personal responsable { get; set; }

        public virtual ICollection<ItemOT> itemsOT { get; set; }

        [Required]
        public bool hab { get; set; }

        public OrdenTrabajo()
        {
            this.itemsOT = new HashSet<ItemOT>();
        }

        public OrdenTrabajo(int aNro, string aNombreTrabajo, Turno aTurno, DateTime aFecha, Personal aJefeSeccion, Personal aResponable)
        {
            this.numero = aNro;
            this.nombre = aNombreTrabajo;
            this.fecha = aFecha;

            this.idTurno = aTurno.idTurno;
            this.Turno = aTurno;

            this.idJefeSeccion = aJefeSeccion.idPersonal;
            this.jefeSeccion = aJefeSeccion;
            this.idResponsable = aResponable.idPersonal;
            this.responsable = aResponable;
            this.hab = true;
        }
    }
}