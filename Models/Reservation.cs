using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

[Table("reservations")] // 👈 important para sakto ang table name
public class Reservation
{
    [Key]
    [Column("ReservationID")]
    public int ReservationID { get; set; }

    [Column("GuestID")]
    public int GuestID { get; set; }

    [Column("RoomID")]
    public int RoomID { get; set; }

    [Column("CheckInDate")]
    public DateTime CheckInDate { get; set; }

    [Column("CheckOutDate")]
    public DateTime CheckOutDate { get; set; }

    [Column("Status")]
    public string? Status { get; set; } = "Pending";
}