using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FraudVSCulture.Models
{
    public class CulturaPais
    {
        public int Id { get; set; }
        public string Pais { get; set; }
        public string Imagen { get; set; }
        public string Resumen { get; set; }
        public List<string> Riesgos { get; set; }
        public int D1 { get; set; }
        public int D2 { get; set; }
        public int D3 { get; set; }
        public int D4 { get; set; }
        public int D5 { get; set; }
        public int D6 { get; set; }
        
    }
}
