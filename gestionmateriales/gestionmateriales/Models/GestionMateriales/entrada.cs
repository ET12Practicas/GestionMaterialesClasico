using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Entrada")]
    public class Entrada
    {
        [Key]
        [Required]
        public int idEntrada { get; set; }

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
        public int idMaterial { get; set; }
        
        public virtual Material Material { get; set; }

        [Required]
        public int idTipoEntrada { get; set; }

        public virtual TipoEntrada tipoEntrada { get; set; }

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

        public Entrada()
        {

        }

        public Entrada(DateTime unaFecha, Material unMaterial, string unCodigoMaterial, string unCodigoDocumento, int unaCantidad, TipoEntrada unTipoEntrada)
        {
            this.fecha = unaFecha;
            this.Material = unMaterial;
            this.codigoMaterial = unCodigoMaterial;
            this.codigoDocumento = unCodigoDocumento;
            this.cantidad = unaCantidad;
            this.tipoEntrada = unTipoEntrada;
        }

        public void SumarStockMaterial()
        {
            Material.stockActual = Material.stockActual + cantidad;
            if(Material.stockActual < Material.stockMinimo)
            {
                Material.estado = "Stock Bajo";
            }
            else
            {
                Material.estado = "Stock Alto";
            }
        }
    }
}