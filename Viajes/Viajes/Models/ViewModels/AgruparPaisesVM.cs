using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Viajes.Models.ViewModels
{
    public class AgruparPaisesVM
    {
        public List<Pais> Paises { get; set; }
        public List<string> PaisContinente { get; set; }
    }
}
