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
        public async Task<List<Plan>> GetPlanesByCiudadyTipoAsync(string ciudad, string tipo)
        {
            List<Plan> planes = await _context.Planes.Include(x => x.Ciudad).ThenInclude(y => y.Pais).OrderBy(x=>x.Nombre).ToListAsync();

            if (String.IsNullOrEmpty(ciudad) && String.IsNullOrEmpty(tipo))
            {
                return planes;
            }

            if (!String.IsNullOrEmpty(ciudad))
            {
                planes= planes.Where(x => x.Ciudad.Nombre.ToLower().Contains(ciudad.ToLower())).ToList();
            }
            if (!String.IsNullOrEmpty(tipo))
            {
                planes = planes.Where(x => x.Tipo == tipo).ToList();
            }
            return planes;
        }



        public List<string> GetTipos()
        {
            return _context.Planes.Select(x => x.Tipo).Distinct().ToList();
        }

        public async Task<List<Plan>> GetPlanesByCiudadIdAsync(int ciudadId)
        {
            return await _context.Planes.Where(x => x.CiudadId == ciudadId).ToListAsync();
        }

        public async Task CreatePlanAsync(Plan plan)
        {
            //plan.FechaPublicacion = DateTime.Now;
            //plan.Revisado = false;
            //plan.CantidadValoraciones = 0;
            //plan.ValoracionMedia = 0;
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
            return await _context.Planes.ToListAsync();
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
