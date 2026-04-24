using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class User
{
    [Key]
    [Column("user_id")]
    public int Id { get; set; }   // ✅ REQUIRED

    public required string Username { get; set; }

    [Column("password_hash")]
    public required string PasswordHash { get; set; }

    public required string Role { get; set; }

    public required string Email { get; set; }
}