using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class Invoice
{
    public int Id { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("subtotal")]
    public decimal Subtotal { get; set; }

    [Column("tax")]
    public decimal Tax { get; set; }

    [Column("discount")]
    public decimal Discount { get; set; }

    [Column("total")]
    public decimal Total { get; set; }

    [Column("issued_date")]
    public DateTime IssuedDate { get; set; } = DateTime.Now;
}