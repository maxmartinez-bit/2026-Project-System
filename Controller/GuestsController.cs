using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class GuestsController : ControllerBase
{
    private readonly AppDbContext _context;

    public GuestsController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Guest>>> GetAll()
    {
        var guests = await _context.Guests.ToListAsync();
        return Ok(guests);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Guest>> Get(int id)
    {
        var guest = await _context.Guests.FindAsync(id);

        if (guest == null)
            return NotFound($"Guest with ID {id} not found.");

        return Ok(guest);
    }

    // CREATE
    [HttpPost]
    public async Task<ActionResult<Guest>> Create([FromBody] Guest guest)
    {
        if (guest == null)
            return BadRequest("Invalid guest data.");

        guest.CreatedAt = DateTime.UtcNow;

        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = guest.Id }, guest);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<ActionResult<Guest>> Update(int id, [FromBody] Guest guest)
    {
        if (id != guest.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Guests.FindAsync(id);

        if (existing == null)
            return NotFound($"Guest with ID {id} not found.");

        // keep CreatedAt original (important)
        guest.CreatedAt = existing.CreatedAt;

        _context.Entry(existing).CurrentValues.SetValues(guest);

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var guest = await _context.Guests.FindAsync(id);

        if (guest == null)
            return NotFound($"Guest with ID {id} not found.");

        _context.Guests.Remove(guest);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Guest deleted successfully" });
    }
}