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

    // =========================================
    // GET ALL
    // =========================================
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Invoice>>> GetAll()
    {
        return Ok(await _context.Invoices.ToListAsync());
    }

    // =========================================
    // GET BY ID
    // =========================================
    [HttpGet("{id}")]
    public async Task<ActionResult<Invoice>> Get(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);

        if (invoice == null)
            return NotFound($"Invoice {id} not found.");

        return Ok(invoice);
    }

    // =========================================
    // CREATE INVOICE
    // =========================================
    [HttpPost]
    public async Task<ActionResult<Invoice>> Create([FromBody] Invoice invoice)
    {
        // 🔍 FIND RESERVATION
        var reservation = await _context.Reservations
            .FirstOrDefaultAsync(r =>
                r.ReservationID == invoice.ReservationID);

        if (reservation == null)
            return BadRequest("Reservation not found.");

        // 🔍 FIND ROOM
        var room = await _context.Rooms
            .FirstOrDefaultAsync(r =>
                r.RoomID == reservation.RoomID);

        if (room == null)
            return BadRequest("Room not found.");

        // =========================================
        // CALCULATE NUMBER OF NIGHTS
        // =========================================
        var nights =
            (reservation.CheckOutDate -
             reservation.CheckInDate).Days;

        // minimum 1 night
        if (nights <= 0)
            nights = 1;

        // =========================================
        // ROOM TOTAL
        // =========================================
        var roomTotal = room.Price * nights;

        // =========================================
        // SERVICES TOTAL
        // =========================================
        var servicesTotal = await _context.ReservationServices
            .Where(x =>
                x.ReservationId == invoice.ReservationID)
            .SumAsync(x =>
                (decimal?)x.TotalPrice) ?? 0;

        // =========================================
        // GRAND TOTAL
        // =========================================
        invoice.TotalAmount =
            roomTotal + servicesTotal;

        invoice.CreatedAt = DateTime.UtcNow;

        // =========================================
        // CHECK IF INVOICE ALREADY EXISTS
        // =========================================
        var existingInvoice = await _context.Invoices
            .FirstOrDefaultAsync(i =>
                i.ReservationID == invoice.ReservationID);

        if (existingInvoice != null)
        {
            // UPDATE EXISTING
            existingInvoice.TotalAmount =
                invoice.TotalAmount;

            existingInvoice.CreatedAt =
                DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return Ok(existingInvoice);
        }

        // =========================================
        // SAVE NEW
        // =========================================
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new { id = invoice.InvoiceID },
            invoice
        );
    }

    // =========================================
    // UPDATE
    // =========================================
    [HttpPut("{id}")]
    public async Task<ActionResult<Invoice>> Update(
        int id,
        [FromBody] Invoice invoice)
    {
        if (id != invoice.InvoiceID)
            return BadRequest("ID mismatch");

        var existing = await _context.Invoices
            .FindAsync(id);

        if (existing == null)
            return NotFound($"Invoice {id} not found.");

        existing.TotalAmount = invoice.TotalAmount;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // =========================================
    // DELETE
    // =========================================
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var invoice = await _context.Invoices
            .FindAsync(id);

        if (invoice == null)
            return NotFound($"Invoice {id} not found.");

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Invoice deleted successfully"
        });
    }
}