using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class Plan
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(20)]
        public string Tipo { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(40)]
        public string Nombre { get; set; }
        [Required]
        [DataType(DataType.Text)]
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        [Required]
        public bool Revisado { get; set; }
        public DateTime? FechaPublicacion { get; set; } //Se añade cuando Revisado está en modo True
        public double? ValoracionMedia { get; set; }
        public int CantidadValoraciones { get; set; }
        public Ciudad Ciudad { get; set; }
        public int CiudadId { get; set; }
        public AppUser Usuario { get; set; }
    }
}
