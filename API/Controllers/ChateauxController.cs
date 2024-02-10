using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
//[Authorize]
[ApiController]
public class ChateauxController : ControllerBase
{
    private readonly StiveContext _context;

    public ChateauxController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Chateaux
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ChateauLightDto>>> GetChateau()
    {
        return await _context.Chateau
            .Select(c => c.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Chateaux/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ChateauDto>> GetChateau(int id)
    {

        if (id == 0) throw new Exception("Pas d'élément avec l'ID 0");

        var chateau = await _context.Chateau
            .Include(c => c.Produits)
            .Where(c => c.Id == id)
            .Select(c => c.ToDto())
            .FirstOrDefaultAsync();

        if (chateau == null) return NotFound();

        return chateau;
    }

    // PUT: api/Chateaux/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutChateau(int id, Chateau chateau)
    {
        if (id != chateau.Id) return BadRequest();

        _context.Entry(chateau).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ChateauExists(id))
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

    // POST: api/Chateaux
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Chateau>> PostChateau(Chateau chateau)
    {
        _context.Chateau.Add(chateau);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetChateau", new { id = chateau.Id }, chateau);
    }

    // DELETE: api/Chateaux/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChateau(int id)
    {
        var chateau = await _context.Chateau.FindAsync(id);
        if (chateau == null)
        {
            return NotFound();
        }

        _context.Chateau.Remove(chateau);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ChateauExists(int id)
    {
        return _context.Chateau.Any(e => e.Id == id);
    }
}
