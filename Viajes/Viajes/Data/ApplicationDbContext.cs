using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Viajes.Models;

namespace Viajes.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole, string>
    {
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Plan> Planes { get; set; }
        public DbSet<Valoracion> Valoraciones { get; set; }
        public DbSet<Intinerario> Intinerarios { get; set; }
        public DbSet<PlanIntinerario> PlanIntinerarios { get; set; }
        public DbSet<ValoracionIntinerario> ValoracionIntinerarios { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
    }
}
