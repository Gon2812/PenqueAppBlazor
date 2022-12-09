using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenqueAppMobile.Models
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña.")]
        public string Password { get; set; }
    }
}
