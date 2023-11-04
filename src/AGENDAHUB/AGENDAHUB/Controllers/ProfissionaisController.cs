﻿using AGENDAHUB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AGENDAHUB.Controllers
{
    public class ProfissionaisController : Controller
    {
        private readonly AppDbContext _context;

        public ProfissionaisController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Profissionais
        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            var profissionais = await _context.Profissionais
                .Where(p => p.UsuarioID == userId) // Restringe os profissionais pelo UsuarioID
                .ToListAsync();

            return View(profissionais);
        }

        // GET: Profissionais/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Profissionais == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            var profissional = await _context.Profissionais
                .Where(p => p.UsuarioID == userId) // Restringe os profissionais pelo UsuarioID
                .FirstOrDefaultAsync(p => p.ID_Profissionais == id);

            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // GET: Profissionais/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profissionais/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Profissionais,Nome,Especializacao,Telefone,Email,Senha,Login,CPF")] Profissionais profissionais)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            profissionais.UsuarioID = userId; // Define o UsuarioID do profissional

            if (ModelState.IsValid)
            {
                _context.Profissionais.Add(profissionais);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(profissionais);
        }

        // GET: Profissionais/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Profissionais == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            var profissional = await _context.Profissionais
                .Where(p => p.UsuarioID == userId) // Restringe os profissionais pelo UsuarioID
                .FirstOrDefaultAsync(p => p.ID_Profissionais == id);

            if (profissional == null)
            {
                return NotFound();
            }
            return View(profissional);
        }

        // POST: Profissionais/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Profissionais,Nome,Especializacao,Telefone,Email,Senha,Login,CPF")] Profissionais profissionais)
        {
            if (id != profissionais.ID_Profissionais)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            profissionais.UsuarioID = userId; // Define o UsuarioID do profissional

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profissionais);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissionaisExists(profissionais.ID_Profissionais))
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
            return View(profissionais);
        }

        // GET: Profissionais/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Profissionais == null)
            {
                return NotFound();
            }

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            var profissional = await _context.Profissionais
                .Where(p => p.UsuarioID == userId) // Restringe os profissionais pelo UsuarioID
                .FirstOrDefaultAsync(p => p.ID_Profissionais == id);

            if (profissional == null)
            {
                return NotFound();
            }

            return View(profissional);
        }

        // POST: Profissionais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Profissionais == null)
            {
                return Problem("Entity set 'AppDbContext.Profissionais' is null.");
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); // Obtém o ID do usuário logado

            var profissional = await _context.Profissionais
                .Where(p => p.UsuarioID == userId) // Restringe os profissionais pelo UsuarioID
                .FirstOrDefaultAsync(p => p.ID_Profissionais == id);

            if (profissional != null)
            {
                _context.Profissionais.Remove(profissional);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProfissionaisExists(int id)
        {
            return _context.Profissionais.Any(e => e.ID_Profissionais == id);
        }
    }
}
