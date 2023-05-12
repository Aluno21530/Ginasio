using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Ginasio.Data;
using Ginasio.Models;

namespace Ginasio.Controllers
{
    public class TreinamentosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TreinamentosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Treinamentos
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Treinamentos.Include(t => t.Instrutor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Treinamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Treinamentos == null)
            {
                return NotFound();
            }

            var treinamentos = await _context.Treinamentos
                .Include(t => t.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinamentos == null)
            {
                return NotFound();
            }

            return View(treinamentos);
        }

        // GET: Treinamentos/Create
        public IActionResult Create()
        {
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id");
            return View();
        }

        // POST: Treinamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,DataInicio,DataTermino,InstrutorFK")] Treinamentos treinamentos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(treinamentos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id", treinamentos.InstrutorFK);
            return View(treinamentos);
        }

        // GET: Treinamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Treinamentos == null)
            {
                return NotFound();
            }

            var treinamentos = await _context.Treinamentos.FindAsync(id);
            if (treinamentos == null)
            {
                return NotFound();
            }
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id", treinamentos.InstrutorFK);
            return View(treinamentos);
        }

        // POST: Treinamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,DataInicio,DataTermino,InstrutorFK")] Treinamentos treinamentos)
        {
            if (id != treinamentos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(treinamentos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TreinamentosExists(treinamentos.Id))
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
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id", treinamentos.InstrutorFK);
            return View(treinamentos);
        }

        // GET: Treinamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Treinamentos == null)
            {
                return NotFound();
            }

            var treinamentos = await _context.Treinamentos
                .Include(t => t.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (treinamentos == null)
            {
                return NotFound();
            }

            return View(treinamentos);
        }

        // POST: Treinamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Treinamentos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Treinamentos'  is null.");
            }
            var treinamentos = await _context.Treinamentos.FindAsync(id);
            if (treinamentos != null)
            {
                _context.Treinamentos.Remove(treinamentos);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TreinamentosExists(int id)
        {
          return (_context.Treinamentos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
