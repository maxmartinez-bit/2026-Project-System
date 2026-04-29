using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;
using BeachResortAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(User user)
    {
        if (await _context.Users.AnyAsync(u => u.Username == user.Username))
            return BadRequest("Username already exists");

        user.Role = "customer";

        _context.Users.Add(user);
        await _context.SaveChangesAsync();

        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(User login)
    {
        var user = await _context.Users
            .FirstOrDefaultAsync(u => u.Username == login.Username && u.Password == login.Password);

        if (user == null)
            return Unauthorized("Invalid credentials");

        return Ok(user);
    }
}