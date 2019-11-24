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
    public class PaisesController : Controller
    {
        private readonly IPaises _paisesServices;

        public PaisesController(IPaises paisesServices)
        {
            _paisesServices = paisesServices;
        }

        // GET: Paises
        public async Task<IActionResult> Index()
        {
            AgruparPaisesVM apvm = new AgruparPaisesVM
            {
                Paises = await _paisesServices.GetPaisesAsync(),
                PaisContinente = _paisesServices.GetContinentes()
            };

            return View(apvm);
        }

        // GET: Paises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _paisesServices.GetPaisByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // GET: paises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: paises/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones")] Pais pais)
        {
            if (ModelState.IsValid)
            {
                await _paisesServices.CreatePaisAsync(pais);
                return RedirectToAction(nameof(Index));
            }
            return View(pais);
        }

        // GET: paises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _paisesServices.GetPaisByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            return View(pais);
        }

        // POST: paises/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Tipo,Nombre,Descripcion,Imagen,Revisado,FechaPublicacion,ValoracionMedia,CantidadValoraciones")] Pais pais)
        {
            if (id != pais.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _paisesServices.UpdatePaisAsync(pais);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_paisesServices.PaisExists(pais.Id))
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
            return View(pais);
        }

        // GET: paises/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pais = await _paisesServices.GetPaisByIdAsync(id);
            if (pais == null)
            {
                return NotFound();
            }

            return View(pais);
        }

        // POST: paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pais = await _paisesServices.GetPaisByIdAsync(id);
            await _paisesServices.DeletePaisAsync(pais);
            return RedirectToAction(nameof(Index));
        }

        //private bool PaisExists(int id)
        //{
        //    return _context.Paises.Any(e => e.Id == id);
        //}
    }
}
