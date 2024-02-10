using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommandesController : ControllerBase
{
    private readonly StiveContext _context;

    public CommandesController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Commandes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommandeLightDto>>> GetCommande()
    {
        return await _context.Commande
            .Include(c => c.Fournisseur)
            .Select(c => c.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Commandes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CommandeDto>> GetCommande(int id)
    {
        var commande = await _context.Commande
            .Include(c => c.ListeMouvementStock).ThenInclude(liste => liste.Produit)
            .Include(c => c.Fournisseur)
            .Where(c => c.Id == id)
            .Select(c => c.ToDto())
            .FirstOrDefaultAsync();

        if (commande == null) return NotFound();

        return commande;
    }

    // PUT: api/Commandes/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCommande(int id, Commande commande)
    {
        if (id != commande.Id)
        {
            return BadRequest();
        }

        _context.Entry(commande).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CommandeExists(id))
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

    // POST: api/Commandes
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Commande>> PostCommande(Commande commande)
    {
        _context.Commande.Add(commande);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCommande", new { id = commande.Id }, commande);
    }

    // DELETE: api/Commandes/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommande(int id)
    {
        var commande = await _context.Commande.FindAsync(id);
        if (commande == null)
        {
            return NotFound();
        }

        _context.Commande.Remove(commande);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CommandeExists(int id)
    {
        return _context.Commande.Any(e => e.Id == id);
    }
}
