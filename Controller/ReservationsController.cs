using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ReservationsController(AppDbContext context)
    {
        _context = context;
    }

    // GET ALL
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Reservation>>> GetAll()
    {
        return Ok(await _context.Reservations.ToListAsync());
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Reservation>> Get(int id)
    {
        var data = await _context.Reservations.FindAsync(id);

        if (data == null)
            return NotFound($"Reservation {id} not found.");

        return Ok(data);
    }

    // CREATE
[HttpPost]
public async Task<ActionResult<Reservation>> Create(
    [FromBody] Reservation reservation)
{
    // VALIDATE DATES
    if (reservation.CheckOutDate <= reservation.CheckInDate)
    {
        return BadRequest(
            "Check-out must be after check-in."
        );
    }

    // =========================================
    // CHECK ROOM
    // =========================================
    var room = await _context.Rooms
        .FirstOrDefaultAsync(r =>
            r.RoomID == reservation.RoomID);

    if (room == null)
    {
        return BadRequest("Room not found.");
    }

    // =========================================
    // BLOCK NON-AVAILABLE ROOMS
    // =========================================
    if (room.Status != "Available")
    {
        return BadRequest(
            $"Room is currently {room.Status}."
        );
    }

    // =========================================
    // DEFAULT STATUS
    // =========================================
    reservation.Status = "Reserved";

    // SAVE RESERVATION
    _context.Reservations.Add(reservation);

    // =========================================
    // CHANGE ROOM STATUS TO OCCUPIED
    // =========================================
    room.Status = "Occupied";

    await _context.SaveChangesAsync();

    return Ok(new
    {
        message = "Reservation created successfully"
    });
}

    // UPDATE
    [HttpPut("{id}")]
    public async Task<ActionResult<Reservation>> Update(int id, [FromBody] Reservation reservation)
    {
        if (id != reservation.ReservationID)
            return BadRequest("ID mismatch");

        var existing = await _context.Reservations.FindAsync(id);

        if (existing == null)
            return NotFound($"Reservation {id} not found.");

        if (reservation.CheckOutDate <= reservation.CheckInDate)
            return BadRequest("Invalid date range.");

        existing.GuestID = reservation.GuestID;
        existing.RoomID = reservation.RoomID;
        existing.CheckInDate = reservation.CheckInDate;
        existing.CheckOutDate = reservation.CheckOutDate;
        existing.Status = reservation.Status;

        await _context.SaveChangesAsync();

        return Ok(existing);
    }
     
    [HttpPut("checkin/{id}")]
public async Task<IActionResult> CheckIn(int id)
{
    var reservation =
        await _context.Reservations
        .FirstOrDefaultAsync(r =>
            r.ReservationID == id);

    if (reservation == null)
        return NotFound("Reservation not found.");

    // UPDATE STATUS
    reservation.Status = "Checked-In";

    // FIND ROOM
    var room =
        await _context.Rooms
        .FirstOrDefaultAsync(r =>
            r.RoomID == reservation.RoomID);

    if (room != null)
    {
        room.Status = "Occupied";
    }

    await _context.SaveChangesAsync();

    return Ok(new
    {
        message = "Guest checked-in successfully"
    });
}

[HttpPut("checkout/{id}")]
public async Task<IActionResult> CheckOut(int id)
{
    var reservation =
        await _context.Reservations
        .FirstOrDefaultAsync(r =>
            r.ReservationID == id);

    if (reservation == null)
        return NotFound("Reservation not found.");

    // UPDATE RESERVATION STATUS
    reservation.Status = "Checked-Out";

    // FIND ROOM
    var room =
        await _context.Rooms
        .FirstOrDefaultAsync(r =>
            r.RoomID == reservation.RoomID);

    if (room != null)
    {
        room.Status = "Available";
    }

    await _context.SaveChangesAsync();

    return Ok(new
    {
        message = "Guest checked-out successfully"
    });
}
    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var data = await _context.Reservations.FindAsync(id);

        if (data == null)
            return NotFound($"Reservation {id} not found.");

        _context.Reservations.Remove(data);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Reservation deleted successfully" });
    }
}