using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("OrdenCompra")]
    public class OrdenCompra
    {
        [Key]
        [Required]
        public int IdOrdenCompra { get; set; }

        [Required]
        public int numeroInterno { get; set; }

        [Required]
        public Proveedor proveedor { get; set; }

        [Required]
        public int numeroFactura { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public Personal responsable { get; set; }

        [Required]
        public double total { get; set; }

        [Required]
        public string chequeNro { get; set; }

        [Required]
        public bool hab { get; set; }

        public virtual ICollection<ItemOrdenCompra> itemsOC { get; set; }

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        [StringLength(20)]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime CREATION_DATE { get; set; }

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

        public OrdenCompra()
        {
            this.itemsOC = new HashSet<ItemOrdenCompra>();
            this.hab = true;
        }
    }
}