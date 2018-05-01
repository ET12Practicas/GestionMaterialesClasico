using gestionmateriales.Models.OficinaTecnica.Documentos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    [Table("ItemOrdenPedido")]

    public class ItemOrdenPedido
    {
        [Key]
        [Required]
        public int idItemOrdenPedido { get; set; }

        [Required]
        public int cantidad { get; set; }

        [Required]
        [NotMapped]
        public int idMaterial { get; set; }

        [Required]
        public Material material { get; set; }

        [Required]
        [NotMapped]
        public int idOrdenPedido { get; set; }

        [Required]
        public OrdenPedido ordenPedido { get; set; }

        public ItemOrdenPedido()
        {
        }

        public ItemOrdenPedido(int idOt, int idMat, int cant)
        {
            this.idItemOrdenPedido = idOt;
            this.idMaterial = idMat;
            this.cantidad = cant;
        }
    }
}