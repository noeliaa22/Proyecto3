using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Models;

namespace Viajes.Services
{
    public interface IPaises
    {
        public List<string> GetContinentes();
        public Task<List<Pais>> GetPaisesAsync();
        public Task<Pais> GetPaisByIdAsync(int? id);
        public Task CreatePaisAsync(Pais pais);
        public Task UpdatePaisAsync(Pais pais);
        public Task DeletePaisAsync(Pais pais);
        public bool PaisExists(int? id);
    }
}
