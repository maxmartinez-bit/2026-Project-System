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
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Payments.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        return payment == null ? NotFound() : Ok(payment);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Payment payment)
    {
        // ✅ default values
        if (string.IsNullOrEmpty(payment.PaymentStatus))
            payment.PaymentStatus = "Pending";

        payment.PaymentDate = DateTime.Now;

        _context.Payments.Add(payment);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = payment.Id }, payment);
    }

    // UPDATE (SAFE)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Payment payment)
    {
        if (id != payment.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Payments.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.ReservationId = payment.ReservationId;
        existing.Amount = payment.Amount;
        existing.PaymentMethod = payment.PaymentMethod;
        existing.PaymentStatus = payment.PaymentStatus;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var payment = await _context.Payments.FindAsync(id);
        if (payment == null) return NotFound();

        _context.Payments.Remove(payment);
        await _context.SaveChangesAsync();

        return Ok("Payment deleted successfully");
    }
}