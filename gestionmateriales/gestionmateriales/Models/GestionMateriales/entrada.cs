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
        public string codigo { get; set; }

        [Required]
        public int idMaterial { get; set; }
        
        public virtual Material Material { get; set; }

        public Entrada()
        {

        }

        public void ActualizarStockMaterial()
        {
            Material.stockActual = Material.stockActual + cantidad;
        }

    }
}
