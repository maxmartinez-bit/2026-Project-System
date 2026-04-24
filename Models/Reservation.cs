using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Reservation
{
    [Key]
    [Column("reservation_id")]
    public int Id { get; set; }

    [Column("guest_id")]
    public int GuestId { get; set; }

    [Column("check_in")]
    public DateTime CheckIn { get; set; }

    [Column("check_out")]
    public DateTime CheckOut { get; set; }

    [Column("total_amount")]
    public decimal TotalAmount { get; set; }
}