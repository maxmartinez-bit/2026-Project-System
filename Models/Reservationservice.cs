using System.ComponentModel.DataAnnotations.Schema;

namespace BeachResortAPI.Models;

public class ReservationService
{
    public int Id { get; set; }

    [Column("reservation_id")]
    public int ReservationId { get; set; }

    [Column("service_id")]
    public int ServiceId { get; set; }
}