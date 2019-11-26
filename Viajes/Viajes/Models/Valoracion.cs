using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class Valoracion
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int Puntuacion { get; set; }
        public Plan Plan { get; set; }
        public int PlanId { get; set; }
        public AppUser Usuario { get; set; }
        public string UsuarioId { get; set; }
    }
}
