using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Models;

namespace Viajes.Services
{
    public interface ICiudades
    {
        public Task<List<Ciudad>> GetCiudadesByPaisIdAsync(int paisId);
        public Task<List<Ciudad>> GetCiudadesAsync();
        public Task<Ciudad> GetCiudadByIdAsync(int? id);
        public Task CreateCiudadAsync(Ciudad ciudad);
        public Task UpdateCiudadAsync(Ciudad ciudad);
        public Task DeleteCiudadAsync(Ciudad ciudad);
        public bool CiudadExists(int? id);
    }
}
