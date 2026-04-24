using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class AuditLogsController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuditLogsController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.AuditLogs.ToListAsync());

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var log = await _context.AuditLogs.FindAsync(id);
        return log == null ? NotFound() : Ok(log);
    }

    // CREATE LOG (manual)
    [HttpPost]
    public async Task<IActionResult> Create(AuditLog log)
    {
        log.LogTime = DateTime.Now;

        _context.AuditLogs.Add(log);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = log.Id }, log);
    }

    // DELETE (optional)
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var log = await _context.AuditLogs.FindAsync(id);
        if (log == null) return NotFound();

        _context.AuditLogs.Remove(log);
        await _context.SaveChangesAsync();

        return Ok("Log deleted");
    }
}