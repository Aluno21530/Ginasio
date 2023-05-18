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
    public class InstrutoresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InstrutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Instrutores
        public async Task<IActionResult> Index()
        {
              return _context.Instrutores != null ? 
                          View(await _context.Instrutores.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Instrutores'  is null.");
        }

        // GET: Instrutores/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Instrutores == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // GET: Instrutores/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Instrutores/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataContratacao,Especializacao,Salario")] Instrutores instrutores, IFormFile fotoInst)
        {
            if (fotoInst == null)
            {
                // o utilizador não fez upload de uma imagem
                // vamos adicionar uma imagem prédefinida ao animal
                instrutores.ListaFotografias
                      .Add(new Fotografias
                      {
                          NomeFicheiro = "noUser.png"
                      });
            }
            else
            {
                // há ficheiro. Mas, será que é uma imagem?
                if (fotoInst.ContentType != "image/jpeg" ||
                    fotoInst.ContentType != "image/png")
                {
                    // o ficheiro carregado não é uma imagem
                    // o que fazer?
                    // Vamos fazer o mesmo que quando o utilizador não
                    // fornece uma imagem
                    instrutores.ListaFotografias
                          .Add(new Fotografias
                          {
                              NomeFicheiro = "noUser.png"
                          });
                }
                else
                {
                    // há imagem!!!
                    // determinar o nome da imagem
                    Guid g = Guid.NewGuid();
                    string nomeFoto = g.ToString();
                    // obter a extensão do ficheiro
                    string extensaoNomeFoto = Path.GetExtension(fotoInst.FileName).ToLower();
                    nomeFoto += extensaoNomeFoto;
                    if (ModelState.IsValid)
                    {
                        _context.Add(instrutores);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(instrutores);
        }

        // GET: Instrutores/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Instrutores == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores.FindAsync(id);
            if (instrutores == null)
            {
                return NotFound();
            }
            return View(instrutores);
        }

        // POST: Instrutores/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataContratacao,Especializacao,Salario")] Instrutores instrutores)
        {
            if (id != instrutores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(instrutores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InstrutoresExists(instrutores.Id))
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
            return View(instrutores);
        }

        // GET: Instrutores/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Instrutores == null)
            {
                return NotFound();
            }

            var instrutores = await _context.Instrutores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (instrutores == null)
            {
                return NotFound();
            }

            return View(instrutores);
        }

        // POST: Instrutores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Instrutores == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Instrutores'  is null.");
            }
            var instrutores = await _context.Instrutores.FindAsync(id);
            if (instrutores != null)
            {
                _context.Instrutores.Remove(instrutores);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InstrutoresExists(int id)
        {
          return (_context.Instrutores?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
