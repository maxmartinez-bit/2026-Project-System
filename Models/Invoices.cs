using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Invoice
{
    [Key]
    [Column("InvoiceID")]
    public int InvoiceID { get; set; }

    [Column("ReservationID")]
    public int ReservationID { get; set; }

    [Column("TotalAmount")]
    public decimal TotalAmount { get; set; }

    [Column("CreatedAt")]
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}