using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Data;
using Viajes.Models;

namespace Viajes.Services
{
    public class ValoracionesServices : IValoraciones
    {
        private readonly ApplicationDbContext _context;

        public ValoracionesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Valoracion>> GetValoracionesByPlanIdAsync(int planId)
        {
            return await _context.Valoraciones.Where(x => x.Plan.Id == planId).ToListAsync();
        }

        public async Task CreateValoracionAsync(Valoracion valoracion)
        {
            await _context.AddAsync(valoracion);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteValoracionAsync(Valoracion valoracion)
        {
            _context.Valoraciones.Remove(valoracion);
            await _context.SaveChangesAsync();
        }

        public async Task<Valoracion> GetValoracionByIdAsync(int? id)
        {
            return await _context.Valoraciones.FindAsync(id);
        }

        public async Task<List<Valoracion>> GetValoracionesAsync()
        {
            return await _context.Valoraciones.ToListAsync();
        }

        public async Task UpdateValoracionAsync(Valoracion valoracion)
        {
            _context.Update(valoracion);
            await _context.SaveChangesAsync();
        }

        public bool ValoracionExists(int? id)
        {
            return _context.Valoraciones.Any(e => e.Id == id);
        }
    }
}
