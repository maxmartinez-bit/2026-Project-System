using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Room
{
    [Key]
    [Column("RoomID")]
    public int RoomID { get; set; }

    [Column("RoomNumber")]
    public string? RoomNumber { get; set; }

    [Column("RoomType")]
    public string? RoomType { get; set; }

    [Column("Price")]
    public decimal Price { get; set; }

    [Column("Status")]
    public string? Status { get; set; } = "Available";
}