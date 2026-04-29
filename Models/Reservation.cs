using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class Reservation
{
    public int Id { get; set; }

    [Column("guest_id")]
    public int GuestId { get; set; }

    [Column("room_id")]
    public int RoomId { get; set; }

    [Column("check_in")]
    public DateTime CheckIn { get; set; }

    [Column("check_out")]
    public DateTime CheckOut { get; set; }

    [Column("total_amount")]
    public decimal TotalAmount { get; set; }

    [Column("status")]
    public string Status { get; set; } = "Pending";
}