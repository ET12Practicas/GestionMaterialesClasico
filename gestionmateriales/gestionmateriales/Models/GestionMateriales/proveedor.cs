using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Proveedor")]
    public class Proveedor
    {
        [Key]
        [Required]
        public int idProveedor { get; set; }

        [Required]
        [StringLength(45)]
        public string nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string cuit { get; set; }

        [Required]
        [StringLength(20)]
        public string telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [Required]
        [StringLength(15)]
        public string razonSocial { get; set; }

        [StringLength(45)]
        public string nombreContacto { get; set; }

        [Required]
        [StringLength(30)]
        public string zona { get; set; }

        [Required]
        [StringLength(20)]
        public string horario { get; set; }

        [Required]
        public bool hab { get; set; }

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        [Required]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        [Required]
        [StringLength(20)]
        public string CREATION_DATE { get; set; }

        /// <summary>
        /// Ip desde que se creo la entrada
        /// </summary>
        [Required]
        [StringLength(20)]
        public string CREATION_IP { get; set; }

        /// <summary>
        /// Ultimo usuario que modifico la entrada
        /// </summary>
        [Required]
        public string LAST_UPDATED_BY { get; set; }

        /// <summary>
        /// Fecha de la ultima modificacion 
        /// </summary>
        [Required]
        [StringLength(20)]
        public string LAST_UPDATED_DATE { get; set; }

        /// <summary>
        /// Ultima Ip desde que se modifico la entrada
        /// </summary>
        [Required]
        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public Proveedor()
        {
            this.hab = true;
        }
    }
}
