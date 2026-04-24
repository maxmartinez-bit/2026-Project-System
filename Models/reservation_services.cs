using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class ReservationService
{
    [Key]
    public int Id { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }

    public int Quantity { get; set; }

    [Column("total_price")]
    public decimal TotalPrice { get; set; }
}