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

        public virtual Material Material { get; set; }

        public virtual Personal Personal { get; set; }

        public Salida()
        {
            cantidad = 0;
        }

        public void ActualizarStockMaterial()
        {
            if (Material.stockActual - cantidad >= 0)
            {
                Material.stockActual = Material.stockActual - cantidad;
            }
            else
            {
                throw new InvalidOperationException("No hay stock suficiente del material.");
            }
        }

    }
}