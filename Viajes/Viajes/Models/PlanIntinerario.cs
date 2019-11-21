using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models
{
    public class PlanIntinerario
    {
        public int Id { get; set; }
        public Plan Plan { get; set; }
        public Intinerario Intinerario { get; set; }

    }
}
