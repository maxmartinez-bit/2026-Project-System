using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

[Table("maintenance")]
public class Maintenance
{
    [Key]
    [Column("MaintenanceID")]
    public int MaintenanceID { get; set; }

    [Column("RoomID")]
    public int RoomID { get; set; }

    [Column("Description")]
    public string? Description { get; set; }

    [Column("Status")]
    public string? Status { get; set; } = "Pending";

    [Column("DateReported")]
    public DateTime DateReported { get; set; } = DateTime.UtcNow;
}