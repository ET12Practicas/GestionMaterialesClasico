using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.GestionMateriales
{
    [Table("OrdenPedido")]
    public class OrdenPedido
    {
        [Key]
        [Required]
        public int idOrdenPedido { get; set; }

        [Required]
        public int numOp { get; set; }

        public int numOt { get; set; }

        [Required]
        [StringLength(150)]
        public string destino { get; set; }

        [Required]
        public bool hab { get; set; }

        public virtual ICollection<ItemOP> itemsOP { get; set; }

        public OrdenPedido()
        {
            this.itemsOP = new HashSet<ItemOP>();
            this.hab = true;
        }

        public OrdenPedido(int aNroOP, int aNroOT, string aDestino)
        {
            this.hab = true;

            this.numOp = aNroOP;
            this.numOt = aNroOT;
            this.destino = aDestino;
        }
    }
}
