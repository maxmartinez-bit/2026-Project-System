using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class User
{
    public int Id { get; set; }

    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("username")]
    public string? Username { get; set; }

    [Column("password")]
    public string? Password { get; set; }

    [Column("role")]
    public string Role { get; set; } = "customer";

    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}