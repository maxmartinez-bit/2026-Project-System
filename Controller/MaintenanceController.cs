using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class MaintenanceController : ControllerBase
{
    private readonly AppDbContext _context;

    public MaintenanceController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Maintenance.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var data = await _context.Maintenance.FindAsync(id);
        return data == null ? NotFound() : Ok(data);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Maintenance maintenance)
    {
        // default values
        maintenance.Status = "Pending";
        maintenance.ReportedAt = DateTime.Now;

        _context.Maintenance.Add(maintenance);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = maintenance.Id }, maintenance);
    }

    // UPDATE (SAFE)
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Maintenance maintenance)
    {
        if (id != maintenance.Id)
            return BadRequest("ID mismatch");

        var existing = await _context.Maintenance.FindAsync(id);
        if (existing == null)
            return NotFound();

        existing.RoomId = maintenance.RoomId;
        existing.IssueDescription = maintenance.IssueDescription;
        existing.Status = maintenance.Status;

        // auto set resolved date if completed
        if (maintenance.Status == "Resolved")
            existing.ResolvedAt = DateTime.Now;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Maintenance.FindAsync(id);
        if (data == null) return NotFound();

        _context.Maintenance.Remove(data);
        await _context.SaveChangesAsync();

        return Ok("Maintenance record deleted");
    }
}