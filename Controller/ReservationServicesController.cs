using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationServicesController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.ReservationServices.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await _context.ReservationServices.FindAsync(id);
        return data == null ? NotFound() : Ok(data);
    }

    // CREATE (IMPORTANT LOGIC HERE 🔥)
    [HttpPost]
    public async Task<IActionResult> Create(ReservationService rs)
    {
        // get service price
        var service = await _context.Services.FindAsync(rs.ServiceId);
        if (service == null)
            return BadRequest("Service not found");

        // calculate total price
        rs.TotalPrice = service.Price * rs.Quantity;

        _context.ReservationServices.Add(rs);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = rs.Id }, rs);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, ReservationService rs)
    {
        if (id != rs.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.ReservationServices.FindAsync(id);
        if (existing == null)
            return NotFound();

        var service = await _context.Services.FindAsync(rs.ServiceId);
        if (service == null)
            return BadRequest("Service not found");

        existing.ServiceId = rs.ServiceId;
        existing.Quantity = rs.Quantity;
        existing.TotalPrice = service.Price * rs.Quantity;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.ReservationServices.FindAsync(id);
        if (data == null) return NotFound();

        _context.ReservationServices.Remove(data);
        await _context.SaveChangesAsync();

        return Ok("Deleted successfully");
    }
}