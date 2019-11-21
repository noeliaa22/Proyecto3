using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class Pais
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string Continente { get; set; }
        public List<Ciudad> Ciudades { get; set; }
    }
}
