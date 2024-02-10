using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CorrectionsStockController : ControllerBase
{
    private readonly StiveContext _context;

    public CorrectionsStockController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/CorrectionsStock
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CorrectionStockLightDto>>> GetCorrectionStock()
    {
        return await _context.CorrectionStock
            .Include(cs => cs.Produit)
            .Select(cs => cs.ToLightDto())
            .ToListAsync();
    }

    // GET: api/CorrectionsStock/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CorrectionStockDto>> GetCorrectionStock(int id)
    {
        var correctionStock = await _context.CorrectionStock
            .Include (cs => cs.Produit)
            .Where(cs => cs.Id == id)
            .Select(cs => cs.ToDto())
            .FirstOrDefaultAsync();

        if (correctionStock == null) return NotFound();

        return correctionStock;
    }

    // PUT: api/CorrectionsStock/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCorrectionStock(int id, CorrectionStock correctionStock)
    {
        if (id != correctionStock.Id)
        {
            return BadRequest();
        }

        _context.Entry(correctionStock).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CorrectionStockExists(id))
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

    // POST: api/CorrectionsStock
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CorrectionStock>> PostCorrectionStock(CorrectionStock correctionStock)
    {
        _context.CorrectionStock.Add(correctionStock);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCorrectionStock", new { id = correctionStock.Id }, correctionStock);
    }

    // DELETE: api/CorrectionsStock/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCorrectionStock(int id)
    {
        var correctionStock = await _context.CorrectionStock.FindAsync(id);
        if (correctionStock == null)
        {
            return NotFound();
        }

        _context.CorrectionStock.Remove(correctionStock);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CorrectionStockExists(int id)
    {
        return _context.CorrectionStock.Any(e => e.Id == id);
    }
}
