using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaniersController : ControllerBase
{
    private readonly StiveContext _context;

    public PaniersController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Paniers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PanierDto>>> GetPanier()
    {
        return await _context.Panier
            .Include(p => p.Produits)
            .Select(p => p.ToDto())
            .ToListAsync();
    }

    // GET: api/Paniers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PanierDto>> GetPanier(int id)
    {
        var panier = await _context.Panier
            .Include (p => p.Produits)
            .Where(p => p.Id == id)
            .Select(p => p.ToDto())
            .FirstOrDefaultAsync();

        if (panier == null)
            return NotFound();

        return panier;
    }

    // PUT: api/Paniers/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPanier(int id, Panier panier)
    {
        if (id != panier.Id)
        {
            return BadRequest();
        }

        _context.Entry(panier).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!PanierExists(id))
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

    // POST: api/Paniers
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Panier>> PostPanier(Panier panier)
    {
        _context.Panier.Add(panier);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetPanier", new { id = panier.Id }, panier);
    }

    // DELETE: api/Paniers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePanier(int id)
    {
        var panier = await _context.Panier.FindAsync(id);
        if (panier == null)
        {
            return NotFound();
        }

        _context.Panier.Remove(panier);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool PanierExists(int id)
    {
        return _context.Panier.Any(e => e.Id == id);
    }
}
