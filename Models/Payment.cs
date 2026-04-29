using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class Payment
{
    [Column("payment_id")]
    public int PaymentId { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("amount")]
    public decimal Amount { get; set; }

    [Column("payment_method")]
    public string? PaymentMethod { get; set; }

    [Column("payment_status")]
    public string PaymentStatus { get; set; } = "Pending";

    [Column("payment_date")]
    public DateTime PaymentDate { get; set; } = DateTime.Now;
}