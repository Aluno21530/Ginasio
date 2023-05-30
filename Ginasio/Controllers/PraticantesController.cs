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
    public class PraticantesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PraticantesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Praticantes
        public async Task<IActionResult> Index()
        {
              return _context.Praticantes != null ? 
                          View(await _context.Praticantes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Praticantes'  is null.");
        }

        // GET: Praticantes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Praticantes == null)
            {
                return NotFound();
            }

            var praticantes = await _context.Praticantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (praticantes == null)
            {
                return NotFound();
            }

            return View(praticantes);
        }

        // GET: Praticantes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Praticantes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataInscricao,PlanoTreinamento,StatusPagamento")] Usuarios praticantes, IFormFile fotoPrat)
        {
            if (fotoPrat == null)
            {
                // o utilizador não fez upload de uma imagem
                // vamos adicionar uma imagem prédefinida ao animal
                praticantes.ListaFotografias
                      .Add(new Fotografias
                      {
                          NomeFicheiro = "noUser.png"
                      });
            }
            else
            {
                // há ficheiro. Mas, será que é uma imagem?
                if (fotoPrat.ContentType != "image/jpeg" ||
                    fotoPrat.ContentType != "image/png")
                {
                    // o ficheiro carregado não é uma imagem
                    // o que fazer?
                    // Vamos fazer o mesmo que quando o utilizador não
                    // fornece uma imagem
                    praticantes.ListaFotografias
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
                    string extensaoNomeFoto = Path.GetExtension(fotoPrat.FileName).ToLower();
                    nomeFoto += extensaoNomeFoto;
                    if (ModelState.IsValid)
                    {
                        _context.Add(praticantes);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(praticantes);
        }

        // POST: Praticantes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Sobrenome,Idade,Sexo,DataNascimento,Morada,Telemovel,Email,DataInscricao,PlanoTreinamento,StatusPagamento")] Usuarios praticantes)
        {
            if (id != praticantes.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(praticantes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PraticantesExists(praticantes.Id))
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
            return View(praticantes);
        }

        // GET: Praticantes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Praticantes == null)
            {
                return NotFound();
            }

            var praticantes = await _context.Praticantes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (praticantes == null)
            {
                return NotFound();
            }

            return View(praticantes);
        }

        // POST: Praticantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Praticantes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Praticantes'  is null.");
            }
            var praticantes = await _context.Praticantes.FindAsync(id);
            if (praticantes != null)
            {
                _context.Praticantes.Remove(praticantes);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PraticantesExists(int id)
        {
          return (_context.Praticantes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
