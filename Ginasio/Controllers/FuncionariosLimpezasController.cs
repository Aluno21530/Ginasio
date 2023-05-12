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
    public class FuncionariosLimpezasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FuncionariosLimpezasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: FuncionariosLimpezas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.FuncionariosLimpeza.Include(f => f.Administrador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FuncionariosLimpezas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.FuncionariosLimpeza == null)
            {
                return NotFound();
            }

            var funcionariosLimpeza = await _context.FuncionariosLimpeza
                .Include(f => f.Administrador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionariosLimpeza == null)
            {
                return NotFound();
            }

            return View(funcionariosLimpeza);
        }

        // GET: FuncionariosLimpezas/Create
        public IActionResult Create()
        {
            ViewData["AdmFK"] = new SelectList(_context.Administradores, "Id", "Nome");
            return View();
        }

        // POST: FuncionariosLimpezas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataContratacao,Salario,AdmFK")] FuncionariosLimpeza funcionariosLimpeza)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionariosLimpeza);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AdmFK"] = new SelectList(_context.Administradores, "Id", "Nome", funcionariosLimpeza.AdmFK);
            return View(funcionariosLimpeza);
        }

        // GET: FuncionariosLimpezas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.FuncionariosLimpeza == null)
            {
                return NotFound();
            }

            var funcionariosLimpeza = await _context.FuncionariosLimpeza.FindAsync(id);
            if (funcionariosLimpeza == null)
            {
                return NotFound();
            }
            ViewData["AdmFK"] = new SelectList(_context.Administradores, "Id", "Nome", funcionariosLimpeza.AdmFK);
            return View(funcionariosLimpeza);
        }

        // POST: FuncionariosLimpezas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataContratacao,Salario,AdmFK")] FuncionariosLimpeza funcionariosLimpeza)
        {
            if (id != funcionariosLimpeza.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionariosLimpeza);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionariosLimpezaExists(funcionariosLimpeza.Id))
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
            ViewData["AdmFK"] = new SelectList(_context.Administradores, "Id", "Nome", funcionariosLimpeza.AdmFK);
            return View(funcionariosLimpeza);
        }

        // GET: FuncionariosLimpezas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.FuncionariosLimpeza == null)
            {
                return NotFound();
            }

            var funcionariosLimpeza = await _context.FuncionariosLimpeza
                .Include(f => f.Administrador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionariosLimpeza == null)
            {
                return NotFound();
            }

            return View(funcionariosLimpeza);
        }

        // POST: FuncionariosLimpezas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.FuncionariosLimpeza == null)
            {
                return Problem("Entity set 'ApplicationDbContext.FuncionariosLimpeza'  is null.");
            }
            var funcionariosLimpeza = await _context.FuncionariosLimpeza.FindAsync(id);
            if (funcionariosLimpeza != null)
            {
                _context.FuncionariosLimpeza.Remove(funcionariosLimpeza);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionariosLimpezaExists(int id)
        {
          return (_context.FuncionariosLimpeza?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
