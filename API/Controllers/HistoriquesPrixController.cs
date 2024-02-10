using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HistoriquesPrixController : ControllerBase
{
    private readonly StiveContext _context;

    public HistoriquesPrixController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/HistoriquesPrix
    [HttpGet]
    public async Task<ActionResult<IEnumerable<HistoriquePrix>>> GetHistoriquePrix()
    {
        return await _context.HistoriquePrix.ToListAsync();
    }

    // GET: api/HistoriquesPrix/5
    [HttpGet("{id}")]
    public async Task<ActionResult<HistoriquePrix>> GetHistoriquePrix(int id)
    {
        var historiquePrix = await _context.HistoriquePrix.FindAsync(id);

        if (historiquePrix == null)
        {
            return NotFound();
        }

        return historiquePrix;
    }

    // PUT: api/HistoriquesPrix/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHistoriquePrix(int id, HistoriquePrix historiquePrix)
    {
        if (id != historiquePrix.Id)
        {
            return BadRequest();
        }

        _context.Entry(historiquePrix).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HistoriquePrixExists(id))
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

    // POST: api/HistoriquesPrix
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<HistoriquePrix>> PostHistoriquePrix(HistoriquePrix historiquePrix)
    {
        _context.HistoriquePrix.Add(historiquePrix);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetHistoriquePrix", new { id = historiquePrix.Id }, historiquePrix);
    }

    // DELETE: api/HistoriquesPrix/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHistoriquePrix(int id)
    {
        var historiquePrix = await _context.HistoriquePrix.FindAsync(id);
        if (historiquePrix == null)
        {
            return NotFound();
        }

        _context.HistoriquePrix.Remove(historiquePrix);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HistoriquePrixExists(int id)
    {
        return _context.HistoriquePrix.Any(e => e.Id == id);
    }
}
