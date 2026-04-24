using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Payment
{
    [Key]
    [Column("payment_id")]
    public int Id { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    public decimal Amount { get; set; }

    [Column("payment_method")]
    public string? PaymentMethod { get; set; }

    [Column("payment_status")]
    public string? PaymentStatus { get; set; }

    [Column("payment_date")]
    public DateTime PaymentDate { get; set; }
}