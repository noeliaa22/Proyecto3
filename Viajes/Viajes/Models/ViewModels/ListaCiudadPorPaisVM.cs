using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models.ViewModels
{
    public class ListaCiudadPorPaisVM
    {
        public Pais Pais { get; set; }
        public List<Ciudad> Ciudades { get; set; }

    }
}
