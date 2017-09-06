using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        [Required]
        [StringLength(12)]
        public string estado { get; set; }

        public virtual Proveedor Proveedor { get; set; }

        public virtual ICollection<Entrada> Entrada { get; set; }

        public virtual ICollection<Salida> Salida { get; set; }

        public Material()
        {
            this.Entrada = new HashSet<Entrada>();

            this.Salida = new HashSet<Salida>();
        }
    }
}
