using Microsoft.EntityFrameworkCore;
using Beach_Resort_Management_System.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

    public DbSet<Reservation> Reservations { get; set; }
    public DbSet<Guest> Guests { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Payment> Payments { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Maintenance> Maintenance { get; set; }
    public DbSet<ReservationService> ReservationServices { get; set; }
    public DbSet<AuditLog> AuditLogs { get; set; }
}
