using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models.ViewModels
{
    public class CrearPlanVM
    {
        public string UsuarioId { get; set; }
        public Ciudad Ciudad { get; set; }
        public Plan Plan { get; set; }
    }
}
