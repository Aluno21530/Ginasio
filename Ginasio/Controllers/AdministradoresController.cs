using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ginasio.Data;
using Ginasio.Models;

namespace Ginasio.Controllers
{

    public class AdministradoresController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdministradoresController(ApplicationDbContext context)
        {
            _db = context;
        }

        // GET: Administradores
        public async Task<IActionResult> Index()
        {
              return _db.Administradores != null ? 
                          View(await _db.Administradores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Administradores'  is null.");
        }

        // GET: Administradores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _db.Administradores == null)
            {
                return NotFound();
            }

            var administrador = await _db.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administrador == null)
            {
                return NotFound();
            }

            return View(administrador);
        }

        // GET: Administradores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administradores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataContratacao,Salario,NivelAcesso")] Administradores administradores)
        {
            if (ModelState.IsValid)
            {
                _db.Add(administradores);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(administradores);
        }

        // GET: Administradores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _db.Administradores == null)
            {
                return NotFound();
            }

            var administradores = await _db.Administradores.FindAsync(id);
            if (administradores == null)
            {
                return NotFound();
            }
            return View(administradores);
        }

        // POST: Administradores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataContratacao,Salario,NivelAcesso")] Administradores administradores)
        {
            if (id != administradores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(administradores);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AdministradoresExists(administradores.Id))
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
            return View(administradores);
        }

        // GET: Administradores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _db.Administradores == null)
            {
                return NotFound();
            }

            var administradores = await _db.Administradores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (administradores == null)
            {
                return NotFound();
            }

            return View(administradores);
        }

        // POST: Administradores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_db.Administradores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Administradores'  is null.");
            }
            var administradores = await _db.Administradores.FindAsync(id);
            if (administradores != null)
            {
                _db.Administradores.Remove(administradores);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AdministradoresExists(int id)
        {
          return (_db.Administradores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
