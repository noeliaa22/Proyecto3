using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Viajes.Data;
using Viajes.Models;
using Viajes.Models.ViewModels;
using Viajes.Services;

namespace Viajes.Controllers
{
    public class PlanesController : Controller
    {
        private readonly IPlanes _planesServices;
        private readonly ICiudades _ciudadesServices;
        private readonly IPaises _paisesServices;
        private readonly UserManager<AppUser> _userManager;

        public PlanesController(IPlanes planesServices, ICiudades ciudadesServices, IPaises paisesServices, UserManager<AppUser> userManager)
        {
            _planesServices = planesServices;
            _ciudadesServices = ciudadesServices;
            _paisesServices = paisesServices;
            _userManager = userManager;
        }

        // GET: Planes
        public async Task<IActionResult> Index(string ciudad, string tipo)
        {

            ListaPlanPorCiudadVM lppcvm = new ListaPlanPorCiudadVM
            {
                Paises = await _paisesServices.GetPaisesAsync(),
                PaisContinente = _paisesServices.GetContinentes(),
                TiposPlan = _planesServices.GetTipos(),
                Planes = await _planesServices.GetPlanesByCiudadyTipoAsync(ciudad, tipo)
                //Ciudades = await _ciudadesServices.GetCiudadesByPaisIdAsync(paisId)
            };
            return View(lppcvm);
        }

        public async Task<IActionResult> CityPlan(int ciudadId)
        {
            ListaPlanPorCiudadVM lppcvm = new ListaPlanPorCiudadVM
            {
                Ciudad = await _ciudadesServices.GetCiudadByIdAsync(ciudadId),
                Planes = await _planesServices.GetPlanesByCiudadIdAsync(ciudadId)
            };
            return View(lppcvm);
        }

        // GET: Planes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _planesServices.GetPlanByIdAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }
        
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Actividad()
        {

            ListaPlanPorCiudadVM lppcvm = new ListaPlanPorCiudadVM
            {
                Planes = await _planesServices.GetPlanesAsync(),
                FechasPlan = _planesServices.GetFechas(),
                TiposPlan=_planesServices.GetTipos(),

            };
            return View(lppcvm);
        }
       
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AprobarPlan(int planId)
        {
            Plan plan = await _planesServices.GetPlanByIdAsync(planId);
            plan.Revisado = true;
            await _planesServices.UpdatePlanAsync(plan);
            return Redirect("Actividad");
        }


        [Authorize]
        public async Task<IActionResult> CrearPlan(int ciudadId)
        {
            Ciudad ciudad = await _ciudadesServices.GetCiudadByIdAsync(ciudadId);
            AppUser user = await _userManager.GetUserAsync(User);
            Plan nuevoPlan = new Plan
            {
                Tipo = "",
                Nombre = "",
                Descripcion = "",
                Imagen = "",
                Ciudad = ciudad,
                UsuarioId = user.Id,

                FechaPublicacion = DateTime.Now,
                ValoracionMedia = 0,
                CantidadValoraciones = 0,
            };

            if (await _userManager.IsInRoleAsync(user, "Admin"))
            {
                nuevoPlan.Revisado = true;
            }
            else
            {
                nuevoPlan.Revisado = false;
            }

            return View(nuevoPlan);
        }
        [HttpPost]
        public async Task<IActionResult> ConfirmarPlan([Bind("Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones,CiudadId,UsuarioId")]Plan plan)
        {
            await _planesServices.CreatePlanAsync(plan);

            return RedirectToAction("CityPlan", new { ciudadId = plan.CiudadId });
        }


        // GET: Planes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Planes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones")] Plan plan)
        {
            if (ModelState.IsValid)
            {
                await _planesServices.CreatePlanAsync(plan);
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        // GET: Planes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _planesServices.GetPlanByIdAsync(id);
            if (plan == null)
            {
                return NotFound();
            }
            return View(plan);
        }

        // POST: Planes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones")] Plan plan)
        {
            if (id != plan.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _planesServices.UpdatePlanAsync(plan);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_planesServices.PlanExists(plan.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(plan);
        }

        // GET: Planes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var plan = await _planesServices.GetPlanByIdAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            return View(plan);
        }

        // POST: Planes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plan = await _planesServices.GetPlanByIdAsync(id);
            await _planesServices.DeletePlanAsync(plan);
            return RedirectToAction(nameof(Index));
        }

        //private bool PlanExists(int id)
        //{
        //    return _context.Planes.Any(e => e.Id == id);
        //}
    }
}
