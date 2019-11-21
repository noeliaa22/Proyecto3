using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class Intinerario
    {
        public int Id { get; set; }
        public AppUser Usuario { get; set; }
        public int CantidadValoraciones { get; set; }
        public double? ValoracionMedia { get; set; }

       
    }
}
