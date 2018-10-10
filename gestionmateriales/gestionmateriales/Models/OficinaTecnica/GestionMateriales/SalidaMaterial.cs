using gestionmateriales.Models.OficinaTecnica.Tipos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    [Table("SalidaMaterial")]
    public class SalidaMaterial
    {
        [Key]
        [Required]
        public int idSalidaMaterial { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoMaterial { get; set; }

        [Required]
        [StringLength(15)]
        public string codigoDocumento { get; set; }

        [Required]
        [NotMapped]
        public int idMaterial { get; set; }

        [Required]
        public virtual Material material { get; set; }

        [Required]
        [NotMapped]
        public int idTipoSalidaMaterial { get; set; }

        [Required]
        public virtual TipoSalidaMaterial tipoSalidaMaterial { get; set; }

        public string CREATED_BY { get; set; }

        public DateTime CREATION_DATE { get; set; }

        [StringLength(20)]
        public string CREATION_IP { get; set; }

        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        public DateTime LAST_UPDATED_DATE { get; set; }

        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public SalidaMaterial()
        {
            
        }

        public void RestarStockMaterial()
        {
            int nuevoStock = material.stockActual - cantidad;
            material.stockActual = nuevoStock;
        }

        public bool HayStock()
        {
            if (material.stockActual - cantidad < 0)
                return false;
            return true;
        }
    }
}