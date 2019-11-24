using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class Ciudad
    {
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [MaxLength(30)]
        public string Nombre { get; set; }
        public string Imagen { get; set; }
        public string Video { get; set; }
        public Pais Pais { get; set; }
        public int PaisId { get; set; }
        public List<Plan> Planes { get; set; }
    }
}
