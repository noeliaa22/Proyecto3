using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Viajes.Data;
using Viajes.Models;

namespace Viajes.Services
{
    public class PlanesServices : IPlanes
    {
        private readonly ApplicationDbContext _context;

        public PlanesServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreatePlanAsync(Plan plan)
        {
            await _context.AddAsync(plan);

            await _context.SaveChangesAsync();
        }

        public async Task DeletePlanAsync(Plan plan)
        {
            _context.Planes.Remove(plan);
            await _context.SaveChangesAsync();
        }

        public async Task<Plan> GetPlanByIdAsync(int? id)
        {
            return await _context.Planes.FindAsync(id);
        }

        public async Task<List<Plan>> GetPlanesAsync()
        {
            return await _context.Planes.ToListAsync(); ;
        }

        public async Task UpdatePlanAsync(Plan plan)
        {
            _context.Update(plan);
            await _context.SaveChangesAsync();
        }

        public bool PlanExists(int? id)
        {
            return _context.Planes.Any(e => e.Id == id);
        }
    }
}
