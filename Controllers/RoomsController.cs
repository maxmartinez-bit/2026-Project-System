using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class RoomsController : ControllerBase
{
    private readonly AppDbContext _context;

    public RoomsController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Rooms.ToListAsync());

    [HttpPost]
public async Task<IActionResult> Create(Room room)
{
    // 🔒 BASIC VALIDATION
    if (string.IsNullOrEmpty(room.RoomName))
        return BadRequest("Room name is required");

    if (room.Price <= 0)
        return BadRequest("Invalid price");

    if (room.Capacity <= 0)
        return BadRequest("Invalid capacity");

    // DEFAULT VALUE
    room.Status ??= "Available";

    _context.Rooms.Add(room);
    await _context.SaveChangesAsync();

    // ✅ RESTFUL RESPONSE
    return CreatedAtAction(nameof(GetAll), new { id = room.Id }, room);
}

    // UPDATE ROOM
[HttpPut("{id}")]
public async Task<IActionResult> Update(int id, Room room)
{
    if (id != room.Id) return BadRequest();

    var existing = await _context.Rooms.FindAsync(id);
    if (existing == null) return NotFound();

    existing.RoomName = room.RoomName;
    existing.Price = room.Price;
    existing.Capacity = room.Capacity;
    existing.Status = room.Status;
    existing.Image = room.Image;

    await _context.SaveChangesAsync();
    return Ok(existing);
}

// DELETE ROOM
[HttpDelete("{id}")]
public async Task<IActionResult> Delete(int id)
{
    var room = await _context.Rooms.FindAsync(id);
    if (room == null) return NotFound();

    _context.Rooms.Remove(room);
    await _context.SaveChangesAsync();

    return Ok("Room deleted");
}
}