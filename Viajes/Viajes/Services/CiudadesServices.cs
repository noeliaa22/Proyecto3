using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Data;
using Viajes.Models;

namespace Viajes.Services
{
    public class CiudadesServices : ICiudades
    {
        private readonly ApplicationDbContext _context;

        public CiudadesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Ciudad>> GetCiudadesByPaisIdAsync(int paisId)
        {
            return await _context.Ciudades.Where(x => x.PaisId == paisId).ToListAsync();
        }


        public async Task CreateCiudadAsync(Ciudad ciudad)
        {
            await _context.AddAsync(ciudad);

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCiudadAsync(Ciudad ciudad)
        {
            _context.Ciudades.Remove(ciudad);
            await _context.SaveChangesAsync();
        }

        public async Task<Ciudad> GetCiudadByIdAsync(int? id)
        {
            return await _context.Ciudades.FindAsync(id);
        }


        public async Task<List<Ciudad>> GetCiudadesAsync()
        {
            return await _context.Ciudades.ToListAsync();
        }

        public async Task UpdateCiudadAsync(Ciudad ciudad)
        {
            _context.Update(ciudad);
            await _context.SaveChangesAsync();
        }

        public bool CiudadExists(int? id)
        {
            return _context.Ciudades.Any(e => e.Id == id);
        }
    }
}
