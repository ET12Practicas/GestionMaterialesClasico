using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.OficinaTecnica.GestionMateriales
{
    /// <summary>
    /// Clase Personal
    /// Representa a cualquier persona para solicitar y/o retirar materiales..
    /// </summary>
    [Table("Personal")]
    public class Personal
    {
        /// <summary>
        /// Identificador único de cada persona
        /// </summary>
        [Key]
        [Required]
        public int idPersonal { get; set; }

        /// <summary>
        /// Primer nombre y apellido de cada persona
        /// </summary>
        [Required]
        [StringLength(60)]
        public string nombre { get; set; }

        /// <summary>
        /// Documento Nacional de Identidad
        /// </summary>
        public int dni { get; set; }

        /// <summary>
        /// Identificador único del personal
        /// </summary>
        [Required]
        public int fichaCensal { get; set; }

        /// <summary>
        /// Campo para borrado logico, 1 visible ? 0 oculto
        /// </summary>
        [Required]
        public bool hab { get; set; }

        /// <summary>
        /// Usuario que creo la entrada
        /// </summary>
        [StringLength(50)]
        public string CREATED_BY { get; set; }

        /// <summary>
        /// Fecha de creacion
        /// </summary>
        public DateTime CREATION_DATE { get; set; }

        /// <summary>
        /// Ip desde que se creo la entrada
        /// </summary>
        [StringLength(20)]
        public string CREATION_IP { get; set; }

        /// <summary>
        /// Ultimo usuario que modifico la entrada
        /// </summary>
        [StringLength(50)]
        public string LAST_UPDATED_BY { get; set; }

        /// <summary>
        /// Fecha de la ultima modificacion 
        /// </summary>
        public DateTime LAST_UPDATED_DATE { get; set; }

        /// <summary>
        /// Ultima Ip desde que se modifico la entrada
        /// </summary>
        [StringLength(20)]
        public string LAST_UPDATED_IP { get; set; }

        /// <summary>
        /// Constructor que inicialliza la clase Personal, por defecto Habilitado: true
        /// </summary>
        public Personal()
        {
            this.hab = true;
        }

        public Personal(string aNombre, int aDni, int aFichaCensal)
        {
            this.nombre = aNombre;
            this.dni = aDni;
            this.fichaCensal = aFichaCensal;
            this.hab = true;
        }
    }
}
