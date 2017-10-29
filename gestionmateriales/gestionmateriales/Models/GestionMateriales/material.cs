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
        public int idUnidad { get; set; }

        public virtual Unidad unidad { get; set; }

        [Required]
        public int idProveedor { get; set; }

        public virtual Proveedor proveedor { get; set; }

        [Required]
        public int idTipoMaterial { get; set; }

        public virtual TipoMaterial tipoMaterial { get; set; }
        
        [Required]
        [StringLength(12)]
        //stock Alto, Bajo, Sin Stock y Pedido//        
        public string estado { get; set; }

        [StringLength(100)]
        public string detalle { get; set; }

        [Required]
        public bool hab { get; set; }

        public virtual ICollection<Entrada> entradas { get; set; }

        public virtual ICollection<Salida> salidas { get; set; }

        public Material()
        {
            this.entradas = new HashSet<Entrada>();
            this.salidas = new HashSet<Salida>();
        }
        public Material(string aCodigo, string aNombre, int aStockMinimo, string aDetalle, Unidad aUnidad, Proveedor aProveedor, TipoMaterial aTipoMaterial)
        {
            this.hab = true;
            this.estado = "Sin Stock";
            this.stockActual = 0;

            this.codigo = aCodigo;
            this.nombre = aNombre;
            this.stockMinimo = aStockMinimo;
            this.detalle = aDetalle;

            this.idUnidad = aUnidad.idUnidad;
            this.unidad = aUnidad;
            this.idProveedor = aProveedor.idProveedor;
            this.proveedor = aProveedor;
            this.idTipoMaterial = aTipoMaterial.idTipoMaterial;
            this.tipoMaterial = aTipoMaterial;
        }
    }
}
