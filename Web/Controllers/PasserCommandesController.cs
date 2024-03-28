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
    public class PasserCommandesController : Controller
    {
        private readonly StiveContext _context;

        public PasserCommandesController(StiveContext context)
        {
            _context = context;
        }

        // GET: PasserCommandes
        public async Task<IActionResult> Index()
        {
            var stiveContext = _context.MouvementStock.Include(m => m.Produit);
            return View(await stiveContext.ToListAsync());
        }

        // GET: PasserCommandes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvementStock = await _context.MouvementStock
                .Include(m => m.Produit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouvementStock == null)
            {
                return NotFound();
            }

            return View(mouvementStock);
        }

        // GET: PasserCommandes/Create
        public IActionResult Create()
        {
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description");
            return View();
        }

        // POST: PasserCommandes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NumeroMouvement,Date,Quantite,Remise,Statut,ProduitId")] MouvementStock mouvementStock)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mouvementStock);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description", mouvementStock.ProduitId);
            return View(mouvementStock);
        }

        // GET: PasserCommandes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvementStock = await _context.MouvementStock.FindAsync(id);
            if (mouvementStock == null)
            {
                return NotFound();
            }
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description", mouvementStock.ProduitId);
            return View(mouvementStock);
        }

        // POST: PasserCommandes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Quantite,Remise,ProduitId")] MouvementStock mouvementStock)
        {
            if (id != mouvementStock.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mouvementStock);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MouvementStockExists(mouvementStock.Id))
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
            ViewData["ProduitId"] = new SelectList(_context.Produit, "Id", "Description", mouvementStock.ProduitId);
            return View(mouvementStock);
        }

        // GET: PasserCommandes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mouvementStock = await _context.MouvementStock
                .Include(m => m.Produit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (mouvementStock == null)
            {
                return NotFound();
            }

            return View(mouvementStock);
        }

        // POST: PasserCommandes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mouvementStock = await _context.MouvementStock.FindAsync(id);
            if (mouvementStock != null)
            {
                _context.MouvementStock.Remove(mouvementStock);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MouvementStockExists(int id)
        {
            return _context.MouvementStock.Any(e => e.Id == id);
        }
    }
}
