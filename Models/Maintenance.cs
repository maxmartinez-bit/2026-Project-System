using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class Maintenance
{
    [Key]
    [Column("maintenance_id")]
    public int Id { get; set; }

    [Column("room_id")]
    public int RoomId { get; set; }

    [Column("issue_description")]
    public string? IssueDescription { get; set; }

    [Column("status")]
    public string? Status { get; set; }

    [Column("reported_at")]
    public DateTime ReportedAt { get; set; }

    [Column("resolved_at")]
    public DateTime? ResolvedAt { get; set; } // nullable
}