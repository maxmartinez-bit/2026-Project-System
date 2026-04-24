using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Room
{
    [Key]
    [Column("room_id")]
    public int Id { get; set; }

    [Column("room_name")]
    public required string RoomName { get; set; }   // ✅ FIX

    public decimal Price { get; set; }

    [Column("availability")]
    public required string Availability { get; set; }  // ✅ FIX
}