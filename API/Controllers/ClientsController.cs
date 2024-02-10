using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Dao;
using Models.Dto;
using Models.Extensions;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly StiveContext _context;

    public ClientsController(StiveContext context)
    {
        _context = context;
    }

    // GET: api/Clients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientLightDto>>> GetClient()
    {
        return await _context.Client
            .Select(c => c.ToLightDto())
            .ToListAsync();
    }

    // GET: api/Clients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetClient(int id)
    {
        var client = await _context.Client
            .Include(c => c.Ventes).ThenInclude(v => v.Produit)
            .Where(c => c.Id == id)
            .Select (c => c.ToDto())
            .FirstOrDefaultAsync();

        if (client == null) return NotFound();

        return client;
    }

    // PUT: api/Clients/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, Client client)
    {
        if (id != client.Id)
        {
            return BadRequest();
        }

        _context.Entry(client).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ClientExists(id))
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

    // POST: api/Clients
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Client>> PostClient(Client client)
    {
        _context.Client.Add(client);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetClient", new { id = client.Id }, client);
    }

    // DELETE: api/Clients/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Client.FindAsync(id);
        if (client == null)
        {
            return NotFound();
        }

        _context.Client.Remove(client);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ClientExists(int id)
    {
        return _context.Client.Any(e => e.Id == id);
    }
}
