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
    public class AulasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AulasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Aulas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Aulas.Include(a => a.Instrutor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Aulas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas
                .Include(a => a.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }

        // GET: Aulas/Create
        public IActionResult Create()
        {
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id");
            return View();
        }

        // POST: Aulas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Descricao,Horario,Duracao,Capacidade,InstrutorFK")] Aulas aulas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aulas);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id", aulas.InstrutorFK);
            return View(aulas);
        }

        // GET: Aulas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas.FindAsync(id);
            if (aulas == null)
            {
                return NotFound();
            }
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id", aulas.InstrutorFK);
            return View(aulas);
        }

        // POST: Aulas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Descricao,Horario,Duracao,Capacidade,InstrutorFK")] Aulas aulas)
        {
            if (id != aulas.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aulas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AulasExists(aulas.Id))
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
            ViewData["InstrutorFK"] = new SelectList(_context.Instrutores, "Id", "Id", aulas.InstrutorFK);
            return View(aulas);
        }

        // GET: Aulas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Aulas == null)
            {
                return NotFound();
            }

            var aulas = await _context.Aulas
                .Include(a => a.Instrutor)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aulas == null)
            {
                return NotFound();
            }

            return View(aulas);
        }

        // POST: Aulas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Aulas == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Aulas'  is null.");
            }
            var aulas = await _context.Aulas.FindAsync(id);
            if (aulas != null)
            {
                _context.Aulas.Remove(aulas);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AulasExists(int id)
        {
          return (_context.Aulas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
