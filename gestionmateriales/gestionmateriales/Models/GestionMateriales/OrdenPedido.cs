using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("Pedido")]
    public class OrdenPedido
    {
        [Key]
        [Required]
        public int idOrdenPedido { get; set; }

        [Required]
        public int nroOrdenPedido { get; set; }

        [Required]
        public int nroOrdenTrabajo { get; set; }

        [Required]
        [StringLength(150)]
        public string destino { get; set; }

        [Required]
        public bool habilitado { get; set; }

        public OrdenPedido()
        {
        }

        public OrdenPedido(int aNroOP, int aNroOT, string aDestino)
        {
            this.habilitado = true;

            this.nroOrdenPedido = aNroOP;
            this.nroOrdenTrabajo = aNroOT;
            this.destino = aDestino;
        }
    }
}
