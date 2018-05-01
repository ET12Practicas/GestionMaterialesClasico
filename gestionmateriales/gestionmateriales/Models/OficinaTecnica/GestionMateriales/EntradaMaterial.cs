using gestionmateriales.Models.OficinaTecnica.Tipos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    [Table("EntradaMaterial")]
    public class EntradaMaterial
    {
        [Key]
        [Required]
        public int idEntradaMaterial { get; set; }

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
        public int idTipoEntradaMaterial { get; set; }

        [Required]
        public virtual TipoEntradaMaterial tipoEntradaMaterial { get; set; }

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        [StringLength(50)]
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

        public EntradaMaterial()
        {

        }

        public EntradaMaterial(DateTime unaFecha, Material unMaterial, string unCodigoDocumento, int unaCantidad, TipoEntradaMaterial unTipoEntrada)
        {
            this.fecha = unaFecha;
            this.material = unMaterial;
            this.codigoMaterial = unMaterial.codigo;
            this.codigoDocumento = unCodigoDocumento;
            this.cantidad = unaCantidad;
            this.tipoEntradaMaterial = unTipoEntrada;
        }

        public void SumarStockMaterial()
        {
            material.stockActual += cantidad;
        }
    }
}