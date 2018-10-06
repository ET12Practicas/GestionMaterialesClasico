using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ordenpedido")]
    public class OrdenPedido
    {
        [Key]
        [Required]
        public int idOrdenPedido { get; set; }

        [Required]
        public int numeroOrdenPedido { get; set; }

        public int numeroOrdenTrabajoAplicacion { get; set; }

        [Required]
        [StringLength(150)]
        public string destino { get; set; }

        [Required]
        public bool hab { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        public DateTime CREATED_BY { get; set; }

        [StringLength(20)]
        public string CREATION_DATE { get; set; }

        [StringLength(20)]
        public string CREATION_IP { get; set; }

        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        public DateTime LAST_UPDATED_DATE { get; set; }

        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public virtual ICollection<ItemOrdenPedido> itemsOP { get; set; }

        public OrdenPedido()
        {
            this.itemsOP = new HashSet<ItemOrdenPedido>();
            this.hab = true;
        }

        public OrdenPedido(int aNroOP, int aNroOT, string aDestino, DateTime aFecha)
        {
            this.hab = true;

            this.numeroOrdenPedido = aNroOP;
            this.numeroOrdenTrabajoAplicacion = aNroOT;
            this.destino = aDestino;
            this.fecha = aFecha;
        }
    }
}
