using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace gestionmateriales.Models.Usuarios
{
    [Table("Rol")]
    public class Rol
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }

        public Rol()
        {
            this.Usuario = new HashSet<Usuario>();
        }
    }
}