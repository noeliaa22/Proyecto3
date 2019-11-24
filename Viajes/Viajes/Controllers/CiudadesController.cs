using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Viajes.Data;
using Viajes.Models;
using Viajes.Models.ViewModels;
using Viajes.Services;

namespace Viajes.Controllers
{
    public class CiudadesController : Controller
    {
        private readonly ICiudades _ciudadesServices;
        private readonly IPaises _paisesServices;

        public CiudadesController(ICiudades ciudadesServices, IPaises paisesServices)
        {
            _ciudadesServices = ciudadesServices;
            _paisesServices = paisesServices;
        }

        // GET: Ciudades
        public async Task<IActionResult> Index()
        {       
            return View(await _ciudadesServices.GetCiudadesAsync());
        }

        public async Task<IActionResult> CountryCity(int paisId)
        {
            ListaCiudadPorPaisVM lcppvm = new ListaCiudadPorPaisVM
            {
                Pais = await _paisesServices.GetPaisByIdAsync(paisId),
                Ciudades = await _ciudadesServices.GetCiudadesByPaisIdAsync(paisId)
            };
            return View(lcppvm);
        }


        // GET: Ciudades/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _ciudadesServices.GetCiudadByIdAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ciudades/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones")] Ciudad ciudad)
        {
            if (ModelState.IsValid)
            {
                await _ciudadesServices.CreateCiudadAsync(ciudad);
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: Ciudades/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _ciudadesServices.GetCiudadByIdAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudades/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones")] Ciudad ciudad)
        {
            if (id != ciudad.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _ciudadesServices.UpdateCiudadAsync(ciudad);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_ciudadesServices.CiudadExists(ciudad.Id))
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
            return View(ciudad);
        }

        // GET: Ciudades/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ciudad = await _ciudadesServices.GetCiudadByIdAsync(id);
            if (ciudad == null)
            {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ciudad = await _ciudadesServices.GetCiudadByIdAsync(id);
            await _ciudadesServices.DeleteCiudadAsync(ciudad);
            return RedirectToAction(nameof(Index));
        }

        //private bool CiudadExists(int id)
        //{
        //    return _context.Ciudades.Any(e => e.Id == id);
        //}
    }
}
