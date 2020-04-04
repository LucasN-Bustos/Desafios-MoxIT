using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Vuelos.Models;

namespace Vuelos.Controllers
{
    public class ClaseVueloesController : Controller
    {
        private readonly VuelosContext _context;
        //funcion que carga la lista
        void cargarLista()
        {
            List<ClaseVuelo> lst = (from d in _context.ClaseVuelo //Cargo la lista con los datos que tengo en la BD
                                    select new ClaseVuelo
                                    {
                                        Id = d.Id,
                                        Vuelo = d.Vuelo
                                    }).ToList();
            List<SelectListItem> items = lst.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Vuelo.ToString(),
                    Value = d.Id.ToString(),
                    Selected = false
                };
            });
            ViewBag.items = items;
        }

        public ClaseVueloesController(VuelosContext context)
        {
            _context = context;
        }

        // GET: ClaseVueloes
        public async Task<IActionResult> Index()
        {
            return View(await _context.ClaseVuelo.ToListAsync());
        }

        // GET: ClaseVueloes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClaseVueloes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Hora,Vuelo,Linea_Aerea,Demorado")] ClaseVuelo claseVuelo)
        {

            if (ModelState.IsValid)
            {
                _context.Add(claseVuelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(claseVuelo);
        }
        //Cargo la lista y la mando al view de Modificar
        public IActionResult Modificar()
        {
            cargarLista();
            return View();
        }

        // GET: ClaseVueloes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claseVuelo = await _context.ClaseVuelo.FindAsync(id);
            if (claseVuelo == null)
            {
                return NotFound();
            }
            return View(claseVuelo);
        }

        // POST: ClaseVueloes/Edit/5
        [HttpPost, ActionName("Modificacion")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Hora,Vuelo,Linea_Aerea,Demorado")] ClaseVuelo claseVuelo)
        {
            if (id != claseVuelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(claseVuelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClaseVueloExists(claseVuelo.Id))
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
            return View(claseVuelo);
        }
        //Cargo la lista y la mando al view de Baja
        public IActionResult Baja()
        {
            cargarLista();
            return View();
        }


        // GET: ClaseVueloes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var claseVuelo = await _context.ClaseVuelo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (claseVuelo == null)
            {
                return NotFound();
            }

            return View(claseVuelo);
        }

        // POST: ClaseVueloes/Delete/5
        [HttpPost, ActionName("DarDeBaja")] //Realiza una accion cuando es llamado por "DarDeBaja"
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var claseVuelo = await _context.ClaseVuelo.FindAsync(id);
            _context.ClaseVuelo.Remove(claseVuelo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private bool ClaseVueloExists(int id)
        {
            return _context.ClaseVuelo.Any(e => e.Id == id);
        }
    }
}