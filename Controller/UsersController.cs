using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;
using Beach_Resort_Management_System.Dto;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserController(AppDbContext context)
    {
        _context = context;
    }

    // =========================================
    // GET ALL USERS
    // =========================================
    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users
            .Select(u => new
            {
                u.Id,
                u.Username,
                u.Role,
                u.CreatedAt
            })
            .ToListAsync();

        return Ok(users);
    }

    // =========================================
    // REGISTER USER / STAFF
    // =========================================
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (_context.Users.Any(u => u.Username == user.Username))
            return BadRequest("Username already exists");

        user.Password =
            BCrypt.Net.BCrypt.HashPassword(user.Password);

        user.Role =
            string.IsNullOrEmpty(user.Role)
            ? "Staff"
            : user.Role;

        user.CreatedAt = DateTime.UtcNow;

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "User created successfully"
        });
    }

    // =========================================
    // LOGIN
    // =========================================
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto request)
    {
        var user = _context.Users
            .FirstOrDefault(u =>
                u.Username == request.Username);

        if (user == null)
            return Unauthorized("Invalid username");

        bool isValid =
            BCrypt.Net.BCrypt.Verify(
                request.Password,
                user.Password
            );

        if (!isValid)
            return Unauthorized("Invalid password");

        return Ok(new
        {
            user.Id,
            user.Username,
            user.Role
        });
    }

    // =========================================
    // DELETE USER
    // =========================================
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound("User not found");

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

        return Ok(new
        {
            message = "User deleted successfully"
        });
    }
}