using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class AppUser:IdentityUser
    {
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(25)]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Apellido { get; set; }
        [Required]
        [MaxLength(10)]
        public string NombreUsuario { get; set; }

    }
}
