using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Invoice
{
    [Key]
    [Column("invoice_id")]
    public int Id { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    public decimal Subtotal { get; set; }

    public decimal Tax { get; set; }

    public decimal Discount { get; set; }

    public decimal Total { get; set; }

    [Column("issued_date")]
    public DateTime IssuedDate { get; set; }
}