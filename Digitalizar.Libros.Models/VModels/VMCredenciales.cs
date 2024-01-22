using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digitalizar.Libros.Models.VModels
{
    public class VMCredenciales
    {
        [Required]
        [EmailAddress(ErrorMessage = "El Correo Registrado no es Valido")]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
