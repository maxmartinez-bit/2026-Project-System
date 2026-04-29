using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class Service
{
    public int Id { get; set; }

    [Column("name")]
    public string? Name { get; set; }

    [Column("description")]
    public string? Description { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("status")]
    public string Status { get; set; } = "Active";
}