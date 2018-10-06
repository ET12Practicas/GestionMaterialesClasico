using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("ordencompra")]
    public class OrdenCompra
    {
        [Key]
        [Required]
        public int IdOrdenCompra { get; set; }

        [Required]
        public int numeroInterno { get; set; }

        [Required]
        [NotMapped]
        public int idProveedor { get; set; }

        [Required]
        public virtual Proveedor proveedor { get; set; }

        [Required]
        public int numeroFactura { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime fecha { get; set; }

        [Required]
        [NotMapped]
        public int idResponsable { get; set; }

        [Required]
        public virtual Personal responsable { get; set; }

        [Required]
        public double total { get; set; }

        [Required]
        public string chequeNro { get; set; }

        [Required]
        public bool hab { get; set; }

        public virtual ICollection<ItemOrdenCompra> itemsOC { get; set; }

        [StringLength(20)]
        public string CREATED_BY { get; set; }

        public DateTime CREATION_DATE { get; set; }

        [StringLength(20)]
        public string CREATION_IP { get; set; }

        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        public DateTime LAST_UPDATED_DATE { get; set; }

        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public OrdenCompra()
        {
            this.itemsOC = new HashSet<ItemOrdenCompra>();
            this.hab = true;
        }
    }
}