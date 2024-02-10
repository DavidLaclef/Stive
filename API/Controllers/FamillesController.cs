using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FamillesController : ControllerBase
{
    private readonly StiveContext _context;

    public FamillesController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Familles
    [HttpGet]
    public async Task<ActionResult<IEnumerable<FamilleLightDto>>> GetFamille()
    {
        return await _context.Famille
            .Select(f => f.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Familles/5
    [HttpGet("{id}")]
    public async Task<ActionResult<FamilleDto>> GetFamille(int id)
    {
        var famille = await _context.Famille
            .Include(f => f.Produits)
            .Where(f => f.Id == id)
            .Select(f => f.ToDto())
            .FirstOrDefaultAsync();

        if (famille == null) return NotFound();

        return famille;
    }

    // PUT: api/Familles/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutFamille(int id, Famille famille)
    {
        if (id != famille.Id)
        {
            return BadRequest();
        }

        _context.Entry(famille).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!FamilleExists(id))
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

    // POST: api/Familles
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Famille>> PostFamille(Famille famille)
    {
        _context.Famille.Add(famille);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetFamille", new { id = famille.Id }, famille);
    }

    // DELETE: api/Familles/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFamille(int id)
    {
        var famille = await _context.Famille.FindAsync(id);
        if (famille == null)
        {
            return NotFound();
        }

        _context.Famille.Remove(famille);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool FamilleExists(int id)
    {
        return _context.Famille.Any(e => e.Id == id);
    }
}
