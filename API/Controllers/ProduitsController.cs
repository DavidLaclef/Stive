using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProduitsController : ControllerBase
{
    private readonly StiveContext _context;

    public ProduitsController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Produits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProduitLightDto>>> GetProduit()
    {
        return await _context.Produit
            .Include(p => p.Chateau)
            .Include(p => p.Familles)
            .Select(p => p.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Produits/SousSeuilReapprovisionnement
    [HttpGet]
    [Route("SousSeuilReapprovisionnement")]
    public async Task<ActionResult<IEnumerable<ProduitLightDto>>> GetProduitSousSeuilReapprovisionnement()
    {
        return await _context.Produit
            .Include(p => p.Chateau)
            .Include(p => p.Familles)
            .Where(p => p.Quantite <= p.SeuilReapprovisionnement)
            .Select(p => p.ToLightDto())
            .ToListAsync();
    }

    // GET: /api/Produits/Medium
    [HttpGet]
    [Route("Medium")]
    public async Task<ActionResult<IEnumerable<ProduitMediumDto>>> GetProduitMedium()
    {
        return await _context.Produit
            .Include(p => p.Chateau)
            .Include(p => p.Familles)
            .Select(c => c.ToMediumDto())
            .ToListAsync();
    }



    // GET: api/Produits/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ProduitDto>> GetProduit(int id)
    {
        var produit = await _context.Produit
            .Include(p => p.Chateau)
            .Include(p => p.HistoriquesPrix)
            .Include(p => p.Familles)
            .Include(p => p.MouvementsStock)
            .Where(p => p.Id == id)
            .Select(p => p.ToDto())
            .FirstOrDefaultAsync();

        if (produit == null) return NotFound();

        return produit;
    }

    // PUT: api/Produits/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutProduit(int id, Produit produit)
    {
        if (id != produit.Id)
        {
            return BadRequest();
        }

        _context.Entry(produit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ProduitExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Produits
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Produit>> PostProduit(Produit produit)
    {
        _context.Produit.Add(produit);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetProduit", new { id = produit.Id }, produit);
    }

    // DELETE: api/Produits/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduit(int id)
    {
        var produit = await _context.Produit.FindAsync(id);
        if (produit == null)
        {
            return NotFound();
        }

        _context.Produit.Remove(produit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ProduitExists(int id)
    {
        return _context.Produit.Any(e => e.Id == id);
    }
}
