using gestionmateriales.Models.OficinaTecnica.GestionMateriales;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace gestionmateriales.Models.OficinaTecnica.Documentos
{
    [Table("remito")]
    public class Remito
    {
        [Key]
        [Required]
        public int IdRemito { get; set; }

        [Required]
        public string numero { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public virtual Proveedor proveedor { get; set; }

        public virtual ICollection<ItemRemito> itemsRemito { get; set; }

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

        public Remito()
        {
            this.itemsRemito = new HashSet<ItemRemito>();
            this.hab = true;
        }
    }
}