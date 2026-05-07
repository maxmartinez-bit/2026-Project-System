using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Room>>> GetAll()
    {
        var rooms = await _context.Rooms.ToListAsync();
        return Ok(rooms);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Room>> Get(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
            return NotFound($"Room with ID {id} not found.");

        return Ok(room);
    }

    // CREATE
    [HttpPost]
    public async Task<ActionResult<Room>> Create([FromBody] Room room)
    {
        if (room == null)
            return BadRequest("Invalid room data.");

        if (string.IsNullOrEmpty(room.Status))
            room.Status = "Available";

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = room.RoomID }, room);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<ActionResult<Room>> Update(int id, [FromBody] Room room)
    {
        if (id != room.RoomID)
            return BadRequest("ID mismatch");

        var existing = await _context.Rooms.FindAsync(id);

        if (existing == null)
            return NotFound($"Room with ID {id} not found.");

        // update fields
        existing.RoomNumber = room.RoomNumber;
        existing.RoomType = room.RoomType;
        existing.Price = room.Price;
        existing.Status = room.Status;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);

        if (room == null)
            return NotFound($"Room with ID {id} not found.");

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Room deleted successfully" });
    }
}