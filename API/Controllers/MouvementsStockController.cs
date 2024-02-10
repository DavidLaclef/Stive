using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MouvementsStockController : ControllerBase
{
    private readonly StiveContext _context;

    public MouvementsStockController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/MouvementsStock
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MouvementStockDto>>> GetMouvementStock()
    {
        return await _context.MouvementStock
            .Include(ms => ms.Produit)
            .Select(ms => ms.ToDto())
            .ToListAsync();
    }

    // GET: api/MouvementsStock/5
    [HttpGet("{id}")]
    public async Task<ActionResult<MouvementStockDto>> GetMouvementStock(int id)
    {
        var mouvementStock = await _context.MouvementStock
            .Include(ms => ms.Produit)
            .Where(ms => ms.Id == id)
            .Select(ms => ms.ToDto())
            .FirstOrDefaultAsync();

        if (mouvementStock == null) return NotFound();

        return mouvementStock;
    }

    // PUT: api/MouvementsStock/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutMouvementStock(int id, MouvementStock mouvementStock)
    {
        if (id != mouvementStock.Id)
        {
            return BadRequest();
        }

        _context.Entry(mouvementStock).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MouvementStockExists(id))
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

    // POST: api/MouvementsStock
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<MouvementStock>> PostMouvementStock(MouvementStock mouvementStock)
    {
        _context.MouvementStock.Add(mouvementStock);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetMouvementStock", new { id = mouvementStock.Id }, mouvementStock);
    }

    // DELETE: api/MouvementsStock/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMouvementStock(int id)
    {
        var mouvementStock = await _context.MouvementStock.FindAsync(id);
        if (mouvementStock == null)
        {
            return NotFound();
        }

        _context.MouvementStock.Remove(mouvementStock);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool MouvementStockExists(int id)
    {
        return _context.MouvementStock.Any(e => e.Id == id);
    }
}
