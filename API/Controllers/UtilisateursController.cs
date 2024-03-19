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
public class UtilisateursController : ControllerBase
{
    private readonly StiveContext _context;

    public UtilisateursController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Utilisateurs
    [HttpGet]
    public async Task<ActionResult<IEnumerable<UtilisateurLightDto>>> GetUtilisateur()
    {
        return await _context.Utilisateur
            .Select(u => u.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Utilisateurs/5
    [HttpGet("{id}")]
    public async Task<ActionResult<UtilisateurDto>> GetUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateur
            .Where(u => u.Id == id)
            .Select(u => u.ToDto())
            .FirstOrDefaultAsync();

        if (utilisateur == null) return NotFound();

        return utilisateur;
    }

    // PUT: api/Utilisateurs/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUtilisateur(int id, Utilisateur utilisateur)
    {
        if (id != utilisateur.Id)
        {
            return BadRequest();
        }

        _context.Entry(utilisateur).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UtilisateurExists(id))
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

    // POST: api/Utilisateurs
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Utilisateur>> PostUtilisateur(Utilisateur utilisateur)
    {
        _context.Utilisateur.Add(utilisateur);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUtilisateur", new { id = utilisateur.Id }, utilisateur);
    }

    // DELETE: api/Utilisateurs/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUtilisateur(int id)
    {
        var utilisateur = await _context.Utilisateur.FindAsync(id);
        if (utilisateur == null)
        {
            return NotFound();
        }

        _context.Utilisateur.Remove(utilisateur);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UtilisateurExists(int id)
    {
        return _context.Utilisateur.Any(e => e.Id == id);
    }
}
