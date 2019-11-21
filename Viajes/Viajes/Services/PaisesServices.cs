using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Data;
using Viajes.Models;

namespace Viajes.Services
{
    public class PaisesServices : IPaises
    {
        private readonly ApplicationDbContext _context;

        public PaisesServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public List<string> GetContinentes()
        {
            return _context.Paises.Select(x => x.Continente).Distinct().ToList();
        }

        public async Task CreatePaisAsync(Pais pais)
        {
            await _context.AddAsync(pais);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePaisAsync(Pais pais)
        {
            _context.Paises.Remove(pais);
            await _context.SaveChangesAsync();
        }

        public async Task<Pais> GetPaisByIdAsync(int? id)
        {
            return await _context.Paises.FindAsync(id);
        }
   

        public async Task<List<Pais>> GetPaisesAsync()
        {
            return await _context.Paises.ToListAsync(); ;
        }

        public async Task UpdatePaisAsync(Pais pais)
        {
            _context.Update(pais);
            await _context.SaveChangesAsync();
        }

        public bool PaisExists(int? id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }
    }
}
