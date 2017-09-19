using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Material")]
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
        public int Unidad_Id { get; set; }

        public virtual Unidad Unidad { get; set; }

        [Required]
        public int Proveedor_Id { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        [Required]
        public int TipoMaterial_Id { get; set; }

        public virtual TipoMaterial TipoMaterial { get; set; }
        
        [Required]
        [StringLength(12)]
        //stock Alto, Bajo, Sin Stock y Pedido//        
        public string estado { get; set; }

        [Required]
        [StringLength(100)]
        public string detalle { get; set; }

        [Required]
        public bool habilitado { get; set; }

        public virtual ICollection<Entrada> Entrada { get; set; }

        public virtual ICollection<Salida> Salida { get; set; }

        public Material()
        {
            this.Entrada = new HashSet<Entrada>();

            this.Salida = new HashSet<Salida>();

            this.habilitado = true;

            this.estado = "Sin Stock";

            this.stockActual = 0;

            this.detalle = "sin detalle";
        }
    }
}
