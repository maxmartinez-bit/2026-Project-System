using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class Guest
{
    public int Id { get; set; }

    [Column("full_name")]
    public string? FullName { get; set; }

    [Column("contact")]
    public string? Contact { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("address")]
    public string? Address { get; set; }
}