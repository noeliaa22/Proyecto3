using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Models;

namespace Viajes.Services
{
    public interface IValoraciones
    {
        public Task<List<Valoracion>> GetValoracionesByPlanIdAsync(int planId);
        public Task<List<Valoracion>> GetValoracionesAsync();
        public Task<Valoracion> GetValoracionByIdAsync(int? id);
        public Task CreateValoracionAsync(Valoracion valoracion);
        public Task UpdateValoracionAsync(Valoracion valoracion);
        public Task DeleteValoracionAsync(Valoracion valoracion);
        public bool ValoracionExists(int? id);
    }
}
