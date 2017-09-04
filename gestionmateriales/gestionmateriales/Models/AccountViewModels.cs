using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace gestionmateriales.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        [StringLength(256)]
        public string Username { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [StringLength(256)]
        [Display(Name = "Usuario")]
        public string Username { get; set; }
        
        [Required]
        [StringLength(256)]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [StringLength(256)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "La contraseña y la contraseña de confirmación no coinciden.")]
        public string ConfirmPassword { get; set; }
    }
}
