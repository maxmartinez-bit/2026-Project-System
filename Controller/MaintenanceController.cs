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

    // =========================================
    // GET ALL
    // =========================================
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Maintenance>>> GetAll()
    {
        return Ok(await _context.Maintenance.ToListAsync());
    }

    // =========================================
    // GET BY ID
    // =========================================
    [HttpGet("{id}")]
    public async Task<ActionResult<Maintenance>> Get(int id)
    {
        var data = await _context.Maintenance.FindAsync(id);

        if (data == null)
            return NotFound($"Maintenance {id} not found.");

        return Ok(data);
    }

    // =========================================
    // CREATE
    // =========================================
    [HttpPost]
    public async Task<ActionResult<Maintenance>> Create(
        [FromBody] Maintenance maintenance)
    {
        if (maintenance == null)
            return BadRequest("Invalid maintenance data.");

        // FIND ROOM
        var room = await _context.Rooms
            .FirstOrDefaultAsync(r =>
                r.RoomID == maintenance.RoomID);

        if (room == null)
            return BadRequest("Room not found.");

        // DEFAULT STATUS
        if (string.IsNullOrEmpty(maintenance.Status))
        {
            maintenance.Status = "Pending";
        }

        // =========================================
        // AUTO ROOM STATUS
        // =========================================
        if (
            maintenance.Status == "Pending" ||
            maintenance.Status == "Ongoing"
        )
        {
            room.Status = "Maintenance";
        }

        if (maintenance.Status == "Fixed")
        {
            room.Status = "Available";
        }

        maintenance.DateReported = DateTime.UtcNow;

        _context.Maintenance.Add(maintenance);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(Get),
            new { id = maintenance.MaintenanceID },
            maintenance
        );
    }

    // =========================================
    // UPDATE
    // =========================================
    [HttpPut("{id}")]
    public async Task<ActionResult<Maintenance>> Update(
        int id,
        [FromBody] Maintenance maintenance)
    {
        if (id != maintenance.MaintenanceID)
            return BadRequest("ID mismatch");

        var existing = await _context.Maintenance
            .FindAsync(id);

        if (existing == null)
            return NotFound($"Maintenance {id} not found.");

        // FIND ROOM
        var room = await _context.Rooms
            .FirstOrDefaultAsync(r =>
                r.RoomID == maintenance.RoomID);

        if (room == null)
            return BadRequest("Room not found.");

        // UPDATE MAINTENANCE
        existing.RoomID = maintenance.RoomID;
        existing.Description = maintenance.Description;
        existing.Status = maintenance.Status;

        // =========================================
        // AUTO ROOM STATUS
        // =========================================
        if (
            maintenance.Status == "Pending" ||
            maintenance.Status == "Ongoing"
        )
        {
            room.Status = "Maintenance";
        }

        if (maintenance.Status == "Fixed")
        {
            room.Status = "Available";
        }

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // =========================================
    // DELETE
    // =========================================
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Maintenance
            .FindAsync(id);

        if (data == null)
            return NotFound($"Maintenance {id} not found.");

        // OPTIONAL:
        // ibalik available after delete
        var room = await _context.Rooms
            .FirstOrDefaultAsync(r =>
                r.RoomID == data.RoomID);

        if (room != null)
        {
            room.Status = "Available";
        }

        _context.Maintenance.Remove(data);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "Maintenance deleted successfully"
        });
    }
}