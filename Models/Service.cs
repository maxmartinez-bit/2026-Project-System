using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Service
{
    [Key]
    [Column("service_id")]
    public int Id { get; set; }

    [Column("service_name")]
    public string? ServiceName { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("price")] // ✅ ADD THIS (IMPORTANT)
    public decimal Price { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("category")]
    public string? Category { get; set; }
}