using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class InvoicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public InvoicesController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Invoices.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        return invoice == null ? NotFound() : Ok(invoice);
    }

    // CREATE (AUTO COMPUTE 🔥)
    [HttpPost]
    public async Task<IActionResult> Create(Invoice invoice)
    {
        // get reservation
        var reservation = await _context.Reservations.FindAsync(invoice.ReservationId);
        if (reservation == null)
            return BadRequest("Reservation not found");

        // get all services linked
        var servicesTotal = await _context.ReservationServices
            .Where(x => x.ReservationId == invoice.ReservationId)
            .SumAsync(x => (decimal?)x.TotalPrice) ?? 0;

        // subtotal = reservation + services
        invoice.Subtotal = reservation.TotalAmount + servicesTotal;

        // tax (example: 10%)
        invoice.Tax = invoice.Subtotal * 0.10m;

        // discount (default 0 if not provided)
        invoice.Discount = invoice.Discount;

        // total
        invoice.Total = invoice.Subtotal + invoice.Tax - invoice.Discount;

        // set date
        invoice.IssuedDate = DateTime.Now;

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = invoice.Id }, invoice);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Invoice invoice)
    {
        if (id != invoice.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Invoices.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.Discount = invoice.Discount;

        // recompute total
        existing.Total = existing.Subtotal + existing.Tax - existing.Discount;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice == null) return NotFound();

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return Ok("Invoice deleted successfully");
    }
}