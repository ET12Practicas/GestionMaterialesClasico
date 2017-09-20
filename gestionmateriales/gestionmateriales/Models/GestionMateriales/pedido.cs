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

        [Required]
        public bool habilitado { get; set; }

        public Pedido()
        {
            this.habilitado = true;
        }
    }
}
