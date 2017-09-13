using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public virtual Material Material { get; set; }

        public virtual Personal Personal { get; set; }

        public Salida()
        {
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