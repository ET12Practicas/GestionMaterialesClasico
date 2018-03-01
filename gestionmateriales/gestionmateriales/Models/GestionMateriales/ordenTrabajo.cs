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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
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

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        [StringLength(50)]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        [StringLength(20)]
        public string CREATION_DATE { get; set; }

        /// <summary>
        /// Ip desde que se creo la entrada
        /// </summary>
        [StringLength(20)]
        public string CREATION_IP { get; set; }

        /// <summary>
        /// Ultimo usuario que modifico la entrada
        /// </summary>
        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        /// <summary>
        /// Fecha de la ultima modificacion 
        /// </summary>
        [StringLength(20)]
        public string LAST_UPDATED_DATE { get; set; }

        /// <summary>
        /// Ultima Ip desde que se modifico la entrada
        /// </summary>
        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public OrdenTrabajo()
        {
            this.itemsOT = new HashSet<ItemOT>();
        }

        public OrdenTrabajo(int aNro, string aNombreTrabajo, Turno aTurno, DateTime aFecha, Personal aJefeSeccion, Personal aResponsable)
        {
            this.numero = aNro;
            this.nombre = aNombreTrabajo;
            this.fecha = aFecha;

            this.idTurno = aTurno.idTurno;
            this.Turno = aTurno;

            this.idJefeSeccion = aJefeSeccion.idPersonal;
            this.jefeSeccion = aJefeSeccion;
            this.idResponsable = aResponsable.idPersonal;
            this.responsable = aResponsable;
            this.hab = true;
        }
    }
}