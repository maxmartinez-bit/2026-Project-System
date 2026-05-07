using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class User
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required]
    [Column("username")]
    public required string Username { get; set; }

    [Required]
    [Column("password")]
    public required string Password { get; set; }

    [Column("role")]
    public string? Role { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}