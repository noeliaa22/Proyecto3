using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viajes.Data;
using Viajes.Models;
using Viajes.Models.ViewModels;
using Viajes.Services;

namespace Viajes.Controllers
{
    public class ValoracionesController : Controller
    {
        private readonly IValoraciones _valoracionesServices;
        private readonly IPlanes _planesServices;
        private readonly UserManager<AppUser> _userManager;

        public ValoracionesController(IValoraciones valoracionesServices, IPlanes planesServices, UserManager<AppUser> userManager)
        {
            _valoracionesServices = valoracionesServices;
            _planesServices = planesServices;
            _userManager = userManager;
        }

        // GET: Valoraciones
        public async Task<IActionResult> Index()
        {
            return View(await _valoracionesServices.GetValoracionesAsync());
        }
        [HttpPost]
        public async Task<IActionResult> Valorar(ListaPlanPorCiudadVM listaPlanPorCiudadVM)
        {
            AppUser user = await _userManager.GetUserAsync(User);
            listaPlanPorCiudadVM.Valoracion.Fecha = DateTime.Now;
            listaPlanPorCiudadVM.Valoracion.Usuario = user;

            await _valoracionesServices.CreateValoracionAsync(listaPlanPorCiudadVM.Valoracion);


            Plan plan = await _planesServices.GetPlanByIdAsync(listaPlanPorCiudadVM.Valoracion.PlanId);
            int cantValoraciones = plan.CantidadValoraciones + 1;
            plan.CantidadValoraciones = cantValoraciones;
            if (plan.CantidadValoraciones == 1)
            {
                double mediaValoracion = (plan.ValoracionMedia + listaPlanPorCiudadVM.Valoracion.Puntuacion) / 1;
                plan.ValoracionMedia = mediaValoracion;
            }
            else if (plan.CantidadValoraciones > 1)
            {
                double mediaValoracion = (plan.ValoracionMedia + listaPlanPorCiudadVM.Valoracion.Puntuacion) / 2;
                plan.ValoracionMedia = mediaValoracion;
            }


            await _planesServices.UpdatePlanAsync(plan);

            return RedirectToActionPermanent("CityPlan", "Planes", new { ciudadId = listaPlanPorCiudadVM.Valoracion.Plan.CiudadId });
            //return RedirectToAction("CityPlan", new { ciudadId = plan.CiudadId });

        }

        // GET: Valoraciones/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracion = await _valoracionesServices.GetValoracionByIdAsync(id);
            if (valoracion == null)
            {
                return NotFound();
            }

            return View(valoracion);
        }

        // GET: Valoraciones/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Valoraciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Fecha,Puntuacion")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                await _valoracionesServices.CreateValoracionAsync(valoracion);
                return RedirectToAction(nameof(Index));
            }
            return View(valoracion);
        }

        // GET: Valoraciones/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracion = await _valoracionesServices.GetValoracionByIdAsync(id);
            if (valoracion == null)
            {
                return NotFound();
            }
            return View(valoracion);
        }

        // POST: Valoraciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Fecha,Puntuacion")] Valoracion valoracion)
        {
            if (id != valoracion.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _valoracionesServices.UpdateValoracionAsync(valoracion);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_valoracionesServices.ValoracionExists(valoracion.Id))
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
            return View(valoracion);
        }

        // GET: Valoraciones/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var valoracion = await _valoracionesServices.GetValoracionByIdAsync(id);
            if (valoracion == null)
            {
                return NotFound();
            }

            return View(valoracion);
        }

        // POST: Valoraciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var valoracion = await _valoracionesServices.GetValoracionByIdAsync(id);
            await _valoracionesServices.DeleteValoracionAsync(valoracion);
            return RedirectToAction(nameof(Index));
        }

    }
}
