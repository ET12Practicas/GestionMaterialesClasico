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
        [StringLength(15)]
        public string razonSocial { get; set; }

        [StringLength(45)]
        public string nombreContacto { get; set; }

        [Required]
        [StringLength(20)]
        public string horario { get; set; }

        [Required]
        public bool habilitado { get; set; }

        public Proveedor()
        {
            this.habilitado = true;
        }
    }
}
