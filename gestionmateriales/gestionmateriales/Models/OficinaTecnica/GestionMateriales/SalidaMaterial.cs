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

        /// <summary>
        /// Usuario que creo la salida
        /// </summary>
        [StringLength(50)]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime CREATION_DATE { get; set; }

        /// <summary>
        /// Ip desde que se creo la salida
        /// </summary>
        [StringLength(20)]
        public string CREATION_IP { get; set; }

        /// <summary>
        /// Ultimo usuario que modifico la salida
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