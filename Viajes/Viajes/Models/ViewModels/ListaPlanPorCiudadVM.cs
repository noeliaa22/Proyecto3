using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models.ViewModels
{
    public class ListaPlanPorCiudadVM
    {
        public Ciudad Ciudad { get; set; }
        public List<Plan> Planes { get; set; }
    }
}
