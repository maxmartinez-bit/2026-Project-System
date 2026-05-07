using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PaymentsController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
    {
        return Ok(await _context.Payments.ToListAsync());
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Payment>> Get(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
            return NotFound($"Payment with ID {id} not found.");

        return Ok(payment);
    }

    [HttpPost]
    public async Task<ActionResult<Payment>> Create([FromBody] Payment payment)
    {
    if (payment == null)
        return BadRequest("Invalid payment data.");

    var invoice = await _context.Invoices
        .FirstOrDefaultAsync(i => i.ReservationID == payment.ReservationID);

    if (invoice == null)
        return BadRequest("No invoice found for this reservation.");

    var totalDue = invoice.TotalAmount;

    var totalPaid = await _context.Payments
        .Where(p => p.ReservationID == payment.ReservationID)
        .SumAsync(p => (decimal?)p.Amount) ?? 0;

    var remaining = totalDue - totalPaid;

    // optional: allow partial payment
    if (payment.Amount > remaining)
        return BadRequest($"Overpayment not allowed. Remaining balance: ₱{remaining}");

    payment.PaymentDate = DateTime.UtcNow;

    _context.Payments.Add(payment);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(Get), new { id = payment.PaymentID }, payment);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<ActionResult<Payment>> Update(int id, [FromBody] Payment payment)
    {
        if (id != payment.PaymentID)
            return BadRequest("ID mismatch");

        var existing = await _context.Payments.FindAsync(id);

        if (existing == null)
            return NotFound($"Payment with ID {id} not found.");

        existing.ReservationID = payment.ReservationID;
        existing.Amount = payment.Amount;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var payment = await _context.Payments.FindAsync(id);

        if (payment == null)
            return NotFound($"Payment with ID {id} not found.");

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Payment deleted successfully" });
    }
}