using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models.ViewModels
{
    public class ListaPlanPorCiudadVM
    {
        public Ciudad Ciudad { get; set; }
        public List<Ciudad> Ciudades { get; set; }
        public List<Plan> Planes { get; set; }
        public Valoracion Valoracion { get; set; }
        public List<Valoracion> Valoraciones { get; set; }
        public List<Pais> Paises { get; set; }
        public List<string> PaisContinente { get; set; }
        public List<string> TiposPlan { get; set; }
    }
}
