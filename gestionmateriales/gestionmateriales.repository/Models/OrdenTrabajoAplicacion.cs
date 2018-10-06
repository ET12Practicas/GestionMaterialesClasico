using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using gestionmateriales.Models.OficinaTecnica.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ordentrabajoaplicacion")]
    public class OrdenTrabajoAplicacion
    {
        [Key]
        [Required]
        public int idOrdenTrabajoAplicacion { get; set; }

        [Required]
        public int numero { get; set; }

        [Required]
        [StringLength(70)]
        public string nombre { get; set; }

        [Required]
        public int idTurno { get; set; }
        
        public virtual Turno turno { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha { get; set; }

        [Required]
        [NotMapped]
        public int idJefeSeccion { get; set; }

        [Required]
        public virtual Personal jefeSeccion { get; set; }

        [Required]
        [NotMapped]
        public int idResponsable { get; set; }

        [Required]
        public virtual Personal responsable { get; set; }

        public virtual ICollection<ItemOrdenTrabajoAplicacion> itemsOTA { get; set; }

        [Required]
        public bool hab { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime CREATION_DATE { get; set; }

        [StringLength(20)]
        public string CREATION_IP { get; set; }

        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        public DateTime LAST_UPDATED_DATE { get; set; }

        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public OrdenTrabajoAplicacion()
        {
            this.itemsOTA = new HashSet<ItemOrdenTrabajoAplicacion>();
            this.hab = true;
        }
    }
}