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

    // ✅ GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
        => Ok(await _context.Rooms.ToListAsync());

    // ✅ GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        return room == null ? NotFound() : Ok(room);
    }

    // ✅ CREATE
    [HttpPost]
    public async Task<IActionResult> Create(Room room)
    {
        // ✅ default value if none provided
        if (string.IsNullOrEmpty(room.Availability))
            room.Availability = "Available";

        _context.Rooms.Add(room);
        await _context.SaveChangesAsync();

        // ✅ proper REST response
        return CreatedAtAction(nameof(Get), new { id = room.Id }, room);
    }

    // ✅ UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, Room room)
    {
        if (id != room.Id)
            return BadRequest("ID mismatch");

        var existingRoom = await _context.Rooms.FindAsync(id);
        if (existingRoom == null)
            return NotFound();

        // ✅ update only fields
        existingRoom.RoomName = room.RoomName;
        existingRoom.Price = room.Price;
        existingRoom.Availability = room.Availability;

        await _context.SaveChangesAsync();

        return Ok(existingRoom);
    }

    // ✅ DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var room = await _context.Rooms.FindAsync(id);
        if (room == null) return NotFound();

        _context.Rooms.Remove(room);
        await _context.SaveChangesAsync();

        return Ok("Room deleted successfully");
    }
}