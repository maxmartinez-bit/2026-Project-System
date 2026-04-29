using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly AppDbContext _context;

    public PaymentsController(AppDbContext context)
    {
        _context = context;
    }

    // 🔍 GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Payments.ToListAsync());

    // 🔍 GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return NotFound();

        return Ok(payment);
    }

    // 💳 CREATE PAYMENT
    [HttpPost]
    public async Task<IActionResult> Pay(Payment payment)
    {
        var invoice = await _context.Invoices
            .FirstOrDefaultAsync(i => i.ReservationId == payment.ReservationId);

        if (invoice == null)
            return BadRequest("No invoice found");

        var totalPaid = await _context.Payments
            .Where(p => p.ReservationId == payment.ReservationId)
            .SumAsync(p => (decimal?)p.Amount) ?? 0;

        var remaining = invoice.Total - totalPaid;

        // 🔥 CLEAN VALIDATION (imong gusto)
        if (payment.Amount < remaining)
            return BadRequest("Insufficient");

        if (payment.Amount > remaining)
            return BadRequest("Overpayment");

        // ✅ EXACT PAYMENT
        payment.PaymentStatus = "Paid";
        payment.PaymentDate = DateTime.Now;

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = payment.PaymentId }, payment);
    }

    // ✏️ UPDATE PAYMENT
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Payment p)
    {
        if (id != p.PaymentId)
            return BadRequest("ID mismatch");

        var existing = await _context.Payments.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.Amount = p.Amount;
        existing.PaymentMethod = p.PaymentMethod;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // ❌ DELETE PAYMENT
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null)
            return NotFound();

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return Ok("Payment deleted");
    }
}