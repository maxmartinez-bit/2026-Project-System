using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

namespace BeachResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public InvoicesController(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 GET ALL
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoices = await _context.Invoices.ToListAsync();
            return Ok(invoices);
        }

        // 🔍 GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
                return NotFound("Invoice not found");

            return Ok(invoice);
        }

        // ➕ GENERATE INVOICE FROM RESERVATION
        [HttpPost("{reservationId}")]
        public async Task<IActionResult> Generate(int reservationId)
        {
            var reservation = await _context.Reservations.FindAsync(reservationId);

            if (reservation == null)
                return BadRequest("Reservation not found");

            // 💰 COMPUTATION
            var subtotal = reservation.TotalAmount;
            var tax = subtotal * 0.10m;
            var discount = 0m;
            var total = subtotal + tax - discount;

            var invoice = new Invoice
            {
                ReservationId = reservationId,
                Subtotal = subtotal,
                Tax = tax,
                Discount = discount,
                Total = total,
                IssuedDate = DateTime.Now
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = invoice.Id }, invoice);
        }

        // ✏️ UPDATE INVOICE (OPTIONAL)
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Invoice updated)
        {
            if (id != updated.Id)
                return BadRequest("ID mismatch");

            var existing = await _context.Invoices.FindAsync(id);

            if (existing == null)
                return NotFound("Invoice not found");

            // 🔄 RECOMPUTE
            existing.Subtotal = updated.Subtotal;
            existing.Tax = updated.Subtotal * 0.10m;
            existing.Discount = updated.Discount;
            existing.Total = existing.Subtotal + existing.Tax - existing.Discount;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // 🗑 DELETE INVOICE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);

            if (invoice == null)
                return NotFound("Invoice not found");

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return Ok("Invoice deleted successfully");
        }
    }
}