using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

namespace BeachResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GuestsController(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 GET ALL GUESTS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var guests = await _context.Guests.ToListAsync();
            return Ok(guests);
        }

        // 🔍 GET GUEST BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
                return NotFound();

            return Ok(guest);
        }

        // ➕ CREATE GUEST
        [HttpPost]
        public async Task<IActionResult> Create(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = guest.Id }, guest);
        }

        // ✏️ UPDATE GUEST
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Guest g)
        {
            if (id != g.Id)
                return BadRequest("ID mismatch");

            var existing = await _context.Guests.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.FullName = g.FullName;
            existing.Contact = g.Contact;
            existing.Email = g.Email;
            existing.Address = g.Address;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // ❌ DELETE GUEST
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var guest = await _context.Guests.FindAsync(id);
            if (guest == null)
                return NotFound();

            _context.Guests.Remove(guest);
            await _context.SaveChangesAsync();

            return Ok("Guest deleted successfully");
        }
    }
}