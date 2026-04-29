using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

namespace BeachResortAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ServicesController(AppDbContext context)
        {
            _context = context;
        }

        // 🔍 GET ALL SERVICES
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var services = await _context.Services.ToListAsync();
            return Ok(services);
        }

        // 🔍 GET BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
                return NotFound();

            return Ok(service);
        }

        // ➕ CREATE SERVICE
        [HttpPost]
        public async Task<IActionResult> Create(Service service)
        {
            _context.Services.Add(service);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = service.Id }, service);
        }

        // ✏️ UPDATE SERVICE
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Service s)
        {
            if (id != s.Id)
                return BadRequest("ID mismatch");

            var existing = await _context.Services.FindAsync(id);
            if (existing == null)
                return NotFound();

            existing.Name = s.Name;
            existing.Description = s.Description;
            existing.Price = s.Price;
            existing.Status = s.Status;
            existing.Image = s.Image;

            await _context.SaveChangesAsync();

            return Ok(existing);
        }

        // ❌ DELETE SERVICE
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var service = await _context.Services.FindAsync(id);
            if (service == null)
                return NotFound();

            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return Ok("Service deleted successfully");
        }
    }
}