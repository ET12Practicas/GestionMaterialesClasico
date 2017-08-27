using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.Usuarios
{
    [Table("Usuario")]
    public class Usuario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(45)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(45)]
        [DataType(DataType.Password)]
        public string Contrasenia { get; set; }

        public int Rol_Id { get; set; }

        public virtual Rol Rol { get; set; }

        public Usuario()
        {

        }
    }
}
