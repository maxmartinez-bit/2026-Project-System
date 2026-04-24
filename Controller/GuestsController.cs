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
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Guests.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        return guest == null ? NotFound() : Ok(guest);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Guest guest)
    {
        guest.CreatedAt = DateTime.Now;

        _context.Guests.Add(guest);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = guest.Id }, guest);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Guest guest)
    {
        if (id != guest.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Guests.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.FullName = guest.FullName;
        existing.ContactNumber = guest.ContactNumber;
        existing.Address = guest.Address;
        existing.Email = guest.Email;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var guest = await _context.Guests.FindAsync(id);
        if (guest == null) return NotFound();

        _context.Guests.Remove(guest);
        await _context.SaveChangesAsync();

        return Ok("Guest deleted successfully");
    }
}