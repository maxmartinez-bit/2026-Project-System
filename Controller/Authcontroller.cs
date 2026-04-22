using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _config;

    public AuthController(IConfiguration config)
    {
        _config = config;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginModel model)
    {
        var conn = new MySqlConnection(_config.GetConnectionString("DefaultConnection"));
        conn.Open();

        var cmd = new MySqlCommand("SELECT * FROM users WHERE username=@u AND password=@p", conn);
        cmd.Parameters.AddWithValue("@u", model.Username);
        cmd.Parameters.AddWithValue("@p", model.Password);

        var reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            return Ok(new
            {
                id = reader["id"],
                username = reader["username"],
                role = reader["role"]
            });
        }

        return Unauthorized("Invalid login");
    }
}

public class LoginModel
{
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}