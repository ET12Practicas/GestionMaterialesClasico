using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Pedido")]
    public class Pedido
    {
        [Key]
        [Required]
        public int idPedido { get; set; }

        [Required]
        public int nroPedido { get; set; }

        [Required]
        public int nroOrdenDeTrabajo { get; set; }

        [Required]
        [StringLength(150)]
        public string destino { get; set; }

        public Pedido()
        {
        }
    }
}
