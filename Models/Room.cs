using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class Room
{
    public int Id { get; set; }

    [Column("room_name")]
    public string? RoomName { get; set; }

    [Column("price")]
    public decimal Price { get; set; }

    [Column("capacity")]
    public int Capacity { get; set; }

    [Column("image")]
    public string? Image { get; set; }

    [Column("status")]
    public string Status { get; set; } = "Available";
}