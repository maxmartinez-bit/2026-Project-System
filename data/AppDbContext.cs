using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Models;


namespace BeachResortAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 🧑 USERS
        public DbSet<User> Users { get; set; }

        // 🏨 ROOMS
        public DbSet<Room> Rooms { get; set; }

        // 🧑‍🤝‍🧑 GUESTS
        public DbSet<Guest> Guests { get; set; }

        // 📅 RESERVATIONS
        public DbSet<Reservation> Reservations { get; set; }

        // 🎯 SERVICES
        public DbSet<Service> Services { get; set; }

        // 🔗 RESERVATION SERVICES
        public DbSet<ReservationService> ReservationServices { get; set; }

        // 🧾 INVOICES
        public DbSet<Invoice> Invoices { get; set; }

        // 💳 PAYMENTS
        public DbSet<Payment> Payments { get; set; }

        // 🔥 OPTIONAL: CUSTOM CONFIG (recommended)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // USERS
            modelBuilder.Entity<User>().ToTable("users");

            // ROOMS
            modelBuilder.Entity<Room>().ToTable("rooms");

            // GUESTS
            modelBuilder.Entity<Guest>().ToTable("guests");

            // RESERVATIONS
            modelBuilder.Entity<Reservation>().ToTable("reservations");

            // SERVICES
            modelBuilder.Entity<Service>().ToTable("services");

            // RESERVATION SERVICES
            modelBuilder.Entity<ReservationService>().ToTable("reservation_services");

            // INVOICES
            modelBuilder.Entity<Invoice>().ToTable("invoices");

            // PAYMENTS
            modelBuilder.Entity<Payment>().ToTable("payments");

            // 🔗 RELATIONSHIPS (optional but clean)
            modelBuilder.Entity<Reservation>()
                .HasOne<Guest>()
                .WithMany()
                .HasForeignKey(r => r.GuestId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Reservation>()
                .HasOne<Room>()
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Invoice>()
                .HasOne<Reservation>()
                .WithMany()
                .HasForeignKey(i => i.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Payment>()
                .HasOne<Reservation>()
                .WithMany()
                .HasForeignKey(p => p.ReservationId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}