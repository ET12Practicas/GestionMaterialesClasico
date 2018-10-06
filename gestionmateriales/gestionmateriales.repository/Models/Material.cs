using gestionmateriales.Models.OficinaTecnica.Tipos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    [Table("material")]
    public class Material
    {
        [Key]
        [Required]
        public int idMaterial { get; set; }

        [Required]
        [StringLength(15)]
        public string codigo { get; set; }

        [Required]
        [StringLength(75)]
        public string nombre { get; set; }

        [Required]
        public int stockActual { get; set; }

        [Required]
        public int stockMinimo { get; set; }

        [Required]
        [NotMapped]
        public int idUnidad { get; set; }

        [Required]
        public virtual Unidad unidad { get; set; }

        [Required]
        [NotMapped]
        public int idProveedor { get; set; }

        [Required]
        public virtual Proveedor proveedor { get; set; }

        [Required]
        [NotMapped]
        public int idTipoMaterial { get; set; }

        [Required]
        public virtual TipoMaterial tipoMaterial { get; set; }

        [StringLength(100)]
        public string detalle { get; set; }

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

        public virtual ICollection<EntradaMaterial> entradas { get; set; }

        public virtual ICollection<SalidaMaterial> salidas { get; set; }

        public Material()
        {
            this.entradas = new HashSet<EntradaMaterial>();
            this.salidas = new HashSet<SalidaMaterial>();

            hab = true;
            detalle = "Sin detalle";
        }
    }
}