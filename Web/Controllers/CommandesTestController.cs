using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;

namespace Web.Controllers
{
    public class CommandesTestController : Controller
    {
        private readonly StiveContext _context;

        public CommandesTestController(StiveContext context)
        {
            _context = context;
        }

        // GET: CommandesTest
        public async Task<IActionResult> Index()
        {
            var stiveContext = _context.Commande.Include(c => c.Produit).Include(c => c.Fournisseur);
            return View(await stiveContext.ToListAsync());
        }

        // GET: CommandesTest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commande
                .Include(c => c.Produit)
                .Include(c => c.Fournisseur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // GET: CommandesTest/Create
        public IActionResult Create()
        {
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description");
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseur, "Id", "AdresseMail");
            return View();
        }

        // POST: CommandesTest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumeroCommande,FournisseurId,Id,NumeroMouvement,Date,Quantite,Remise,Statut,ProduitId")] Commande commande)
        {
            if (ModelState.IsValid)
            {
                _context.Add(commande);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description", commande.ProduitId);
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseur, "Id", "AdresseMail", commande.FournisseurId);
            return View(commande);
        }

        // GET: CommandesTest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commande.FindAsync(id);
            if (commande == null)
            {
                return NotFound();
            }
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description", commande.ProduitId);
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseur, "Id", "AdresseMail", commande.FournisseurId);
            return View(commande);
        }

        // POST: CommandesTest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumeroCommande,FournisseurId,Id,NumeroMouvement,Date,Quantite,Remise,Statut,ProduitId")] Commande commande)
        {
            if (id != commande.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(commande);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandeExists(commande.Id))
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
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description", commande.ProduitId);
            ViewData["FournisseurId"] = new SelectList(_context.Fournisseur, "Id", "AdresseMail", commande.FournisseurId);
            return View(commande);
        }

        // GET: CommandesTest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var commande = await _context.Commande
                .Include(c => c.Produit)
                .Include(c => c.Fournisseur)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (commande == null)
            {
                return NotFound();
            }

            return View(commande);
        }

        // POST: CommandesTest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var commande = await _context.Commande.FindAsync(id);
            if (commande != null)
            {
                _context.Commande.Remove(commande);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommandeExists(int id)
        {
            return _context.Commande.Any(e => e.Id == id);
        }
    }
}
