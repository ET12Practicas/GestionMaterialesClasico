using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
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

        [Required(AllowEmptyStrings = true)]
        [StringLength(100)]
        public string direccion { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string cuit { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string telefono { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(50)]
        public string email { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(15)]
        public string razonSocial { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(45)]
        public string nombreContacto { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(30)]
        public string zona { get; set; }

        [Required(AllowEmptyStrings = true)]
        [StringLength(20)]
        public string horario { get; set; }

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

        public Proveedor()
        {
            this.hab = true;
        }
    }
}
