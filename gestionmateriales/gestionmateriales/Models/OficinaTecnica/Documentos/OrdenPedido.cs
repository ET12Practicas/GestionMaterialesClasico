using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using gestionmateriales.Models.OficinaTecnica.GestionMateriales;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("OrdenPedido")]
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

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        public DateTime CREATED_BY { get; set; }

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
        public DateTime LAST_UPDATED_DATE { get; set; }

        /// <summary>
        /// Ultima Ip desde que se modifico la entrada
        /// </summary>
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
