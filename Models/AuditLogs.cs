using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Beach_Resort_Management_System.Models;

public class AuditLog
{
    [Key]
    [Column("log_id")]
    public int Id { get; set; }

    [Column("user_id")]
    public int UserId { get; set; }

    public string? Action { get; set; }

    public string? Description { get; set; }

    [Column("log_time")]
    public DateTime LogTime { get; set; }
}