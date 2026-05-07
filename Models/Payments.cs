using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

[Table("payments")]
public class Payment
{
    [Key]
    [Column("PaymentID")]
    public int PaymentID { get; set; }

    [Column("ReservationID")]
    public int ReservationID { get; set; }

    [Column("Amount")]
    public decimal Amount { get; set; }

    [Column("PaymentDate")]
    public DateTime PaymentDate { get; set; }
}