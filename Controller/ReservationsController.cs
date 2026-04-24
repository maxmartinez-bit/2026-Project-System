using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Reservations.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await _context.Reservations.FindAsync(id);
        return data == null ? NotFound() : Ok(data);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Reservation reservation)
    {
        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = reservation.Id }, reservation);
    }

    // UPDATE (SAFE)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Reservation reservation)
    {
        if (id != reservation.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Reservations.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.GuestId = reservation.GuestId;
        existing.CheckIn = reservation.CheckIn;
        existing.CheckOut = reservation.CheckOut;
        existing.TotalAmount = reservation.TotalAmount;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Reservations.FindAsync(id);
        if (data == null) return NotFound();

        _context.Reservations.Remove(data);
        await _context.SaveChangesAsync();

        return Ok("Deleted");
    }
}