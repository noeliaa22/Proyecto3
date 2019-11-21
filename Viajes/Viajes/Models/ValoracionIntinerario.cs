using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class ValoracionIntinerario
    {
        public int Id { get; set; } //Una valoracion
        public AppUser Usuario { get; set; }
        public Intinerario Intinerario { get; set; }
        public int Puntuacion { get; set; }
        public DateTime Fecha { get; set; }
    }
}
