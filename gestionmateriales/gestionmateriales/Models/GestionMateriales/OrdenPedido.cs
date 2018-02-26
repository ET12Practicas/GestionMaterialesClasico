using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("OrdenPedido")]
    public class OrdenPedido
    {
        [Key]
        [Required]
        public int idOrdenPedido { get; set; }

        [Required]
        public int numOp { get; set; }

        public int numOt { get; set; }

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
        [Required]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        [Required]
        [StringLength(50)]
        public string CREATION_DATE { get; set; }

        /// <summary>
        /// Ip desde que se creo la entrada
        /// </summary>
        [Required]
        [StringLength(20)]
        public string CREATION_IP { get; set; }

        /// <summary>
        /// Ultimo usuario que modifico la entrada
        /// </summary>
        [Required]
        public string LAST_UPDATED_BY { get; set; }

        /// <summary>
        /// Fecha de la ultima modificacion 
        /// </summary>
        [Required]
        [StringLength(50)]
        public string LAST_UPDATED_DATE { get; set; }

        /// <summary>
        /// Ultima Ip desde que se modifico la entrada
        /// </summary>
        [Required]
        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public virtual ICollection<ItemOP> itemsOP { get; set; }

        public OrdenPedido()
        {
            this.itemsOP = new HashSet<ItemOP>();
            this.hab = true;
        }

        public OrdenPedido(int aNroOP, int aNroOT, string aDestino, DateTime aFecha)
        {
            this.hab = true;

            this.numOp = aNroOP;
            this.numOt = aNroOT;
            this.destino = aDestino;
            this.fecha = aFecha;
        }
    }
}
