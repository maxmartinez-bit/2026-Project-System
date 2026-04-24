using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Guest
{
    [Key]
    [Column("guest_id")]
    public int Id { get; set; }

    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("contact_number")]
    public string? ContactNumber { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    [Column("created_at")]
    public DateTime CreatedAt { get; set; }
}