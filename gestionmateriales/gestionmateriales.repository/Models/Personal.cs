using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    /// <summary>
    /// Clase Personal
    /// Representa a cualquier persona para solicitar y/o retirar materiales..
    /// </summary>
    [Table("personal")]
    public class Personal
    {
        [Key]
        [Required]
        public int idPersonal { get; set; }

        [Required]
        [StringLength(60)]
        public string nombre { get; set; }

        [Required]
        public int dni { get; set; }

        [Required]
        public int fichaCensal { get; set; }

        [Required]
        public bool hab { get; set; }

        [StringLength(50)]
        public string CREATED_BY { get; set; }

        public DateTime CREATION_DATE { get; set; }

        [StringLength(20)]
        public string CREATION_IP { get; set; }

        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        public DateTime LAST_UPDATED_DATE { get; set; }

        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        public Personal()
        {
            this.hab = true;
        }
    }
}
