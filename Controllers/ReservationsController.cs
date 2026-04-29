using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    // 🔍 GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Reservations.ToListAsync());

    // ➕ CREATE RESERVATION + AUTO INVOICE
    [HttpPost]
    public async Task<IActionResult> Create(Reservation reservation)
    {
        var room = await _context.Rooms.FindAsync(reservation.RoomId);
        if (room == null)
            return BadRequest("Room not found");

        if (reservation.CheckOut <= reservation.CheckIn)
            return BadRequest("Invalid dates");

        var days = (reservation.CheckOut - reservation.CheckIn).Days;
        if (days <= 0) days = 1;

        // 💰 COMPUTE TOTAL
        reservation.TotalAmount = days * room.Price;

        _context.Reservations.Add(reservation);
        await _context.SaveChangesAsync();

        // 🔥 AUTO GENERATE INVOICE
        var subtotal = reservation.TotalAmount;
        var tax = subtotal * 0.10m;
        var discount = 0m;
        var total = subtotal + tax - discount;

        var invoice = new Invoice
        {
            ReservationId = reservation.Id,
            Subtotal = subtotal,
            Tax = tax,
            Discount = discount,
            Total = total,
            IssuedDate = DateTime.Now
        };

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAll), new { id = reservation.Id }, reservation);
    }

    // ✏️ UPDATE RESERVATION (RECOMPUTE TOTAL)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Reservation r)
    {
        var existing = await _context.Reservations.FindAsync(id);
        if (existing == null) return NotFound();

        var room = await _context.Rooms.FindAsync(r.RoomId);
        if (room == null)
            return BadRequest("Room not found");

        if (r.CheckOut <= r.CheckIn)
            return BadRequest("Invalid dates");

        var days = (r.CheckOut - r.CheckIn).Days;
        if (days <= 0) days = 1;

        existing.CheckIn = r.CheckIn;
        existing.CheckOut = r.CheckOut;
        existing.RoomId = r.RoomId;
        existing.TotalAmount = days * room.Price;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // ❌ DELETE (CANCEL)
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var r = await _context.Reservations.FindAsync(id);
        if (r == null) return NotFound();

        _context.Reservations.Remove(r);
        await _context.SaveChangesAsync();

        return Ok("Reservation cancelled");
    }
}