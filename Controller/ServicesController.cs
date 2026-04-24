using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicesController(AppDbContext context)
    {
        _context = context;
    }

    // ✅ GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Services.ToListAsync());

    // ✅ GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var service = await _context.Services.FindAsync(id);
        return service == null ? NotFound() : Ok(service);
    }

    // ✅ CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Service service)
    {
        // ✅ default status if not provided
        if (string.IsNullOrEmpty(service.Status))
            service.Status = "Available";

        _context.Services.Add(service);
        await _context.SaveChangesAsync();

        // ✅ proper REST response
        return CreatedAtAction(nameof(Get), new { id = service.Id }, service);
    }

    // ✅ UPDATE (SAFE WAY)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Service service)
    {
        if (id != service.Id)
            return BadRequest("ID mismatch");

        var existingService = await _context.Services.FindAsync(id);
        if (existingService == null)
            return NotFound();

        // ✅ update only fields (SAFE)
        existingService.ServiceName = service.ServiceName;
        existingService.Description = service.Description;
        existingService.Price = service.Price;
        existingService.Status = service.Status;

        await _context.SaveChangesAsync();

        return Ok(existingService);
    }

    // ✅ DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var service = await _context.Services.FindAsync(id);
        if (service == null) return NotFound();

        _context.Services.Remove(service);
        await _context.SaveChangesAsync();

        return Ok("Service deleted successfully");
    }
}