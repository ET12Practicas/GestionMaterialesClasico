using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Salida")]
    public class Salida
    {
        [Key]
        [Required]
        public int idSalida { get; set; }

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
        public int idTipoSalida { get; set; }

        public virtual TipoSalida tipoSalida { get; set; }

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

        public Salida()
        {
            cantidad = 0;
        }

        public void RestarStockMaterial()
        {
            int nuevoStock = Material.stockActual - cantidad;

            Material.stockActual = nuevoStock;

            if (Material.stockActual == 0)
            {
                Material.estado = "Sin Stock";
            }
            else
            {
                if (Material.stockActual < Material.stockMinimo)
                {
                    Material.estado = "Stock Bajo";
                }
                else
                {
                    Material.estado = "Stock Alto";
                }
            }
        }

        public bool HayStockMaterial()
        {
            if (Material.stockActual - cantidad < 0)
            {
                return false;
            }

            return true;
        }
    }
}