using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[Authorize]
[ApiController]
public class FournisseursController : ControllerBase
{
    private readonly StiveContext _context;

    public FournisseursController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Fournisseurs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FournisseurLightDto>>> GetFournisseur()
    {
        return await _context.Fournisseur
            .Select(f => f.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Fournisseurs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FournisseurDto>> GetFournisseur(int id)
    {
        var fournisseur = await _context.Fournisseur
            .Include(f => f.Commandes)
            .Where(f => f.Id == id)
            .Select(f => f.ToDto())
            .FirstOrDefaultAsync();

        if (fournisseur == null) return NotFound();

        return fournisseur;
    }

    // PUT: api/Fournisseurs/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFournisseur(int id, Fournisseur fournisseur)
    {
        if (id != fournisseur.Id)
        {
            return BadRequest();
        }

        _context.Entry(fournisseur).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FournisseurExists(id))
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

    // POST: api/Fournisseurs
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Fournisseur>> PostFournisseur(Fournisseur fournisseur)
    {
        _context.Fournisseur.Add(fournisseur);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFournisseur", new { id = fournisseur.Id }, fournisseur);
    }

    // DELETE: api/Fournisseurs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFournisseur(int id)
    {
        var fournisseur = await _context.Fournisseur.FindAsync(id);
        if (fournisseur == null)
        {
            return NotFound();
        }

        _context.Fournisseur.Remove(fournisseur);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FournisseurExists(int id)
    {
        return _context.Fournisseur.Any(e => e.Id == id);
    }
}
