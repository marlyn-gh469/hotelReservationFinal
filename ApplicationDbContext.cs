using Microsoft.EntityFrameworkCore;
using HotelReservationFinal.Models; // Adjust namespace based on your project

namespace HotelReservationFinal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        // Define tables (DbSet)
        public DbSet<Users> Users { get; set; }
        public DbSet<Rooms> Rooms { get; set; }
        public DbSet<RoomCategories> RoomCategories { get; set; }
        public DbSet<Bookings> Bookings { get; set; }
        public DbSet<CheckInOut> CheckInOuts { get; set; }
        public DbSet<Housekeeping> Housekeeping { get; set; }
       
        public DbSet<MaintenanceRequests> MaintenanceRequests { get; set; }
        public DbSet<Notifications> Notifications { get; set; }
        public DbSet<Payments> Payments { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<Roles> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial roles
            modelBuilder.Entity<Roles>().HasData(
                new Roles { RoleId = 1, RoleName = "Admin" },
                new Roles { RoleId = 2, RoleName = "Guest" }
            );

            // Define decimal precision for financial fields
          
            modelBuilder.Entity<Payments>()
                .Property(p => p.Amount)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Payments>()
                .HasOne(p => p.User)
                .WithMany()
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Payments>()
                .HasOne(p => p.Booking)
                .WithMany()
                .HasForeignKey(p => p.BookingId)
                .OnDelete(DeleteBehavior.Cascade);



            modelBuilder.Entity<Rooms>()
                .Property(r => r.PricePerNight)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Reports>()
                .Property(r => r.TotalRevenue)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<Bookings>()
                .Property(b => b.TotalAmount)
                .HasColumnType("decimal(18,2)");

       
          

            // Fix potential cycle in CheckInOut
            modelBuilder.Entity<CheckInOut>()
                .HasOne(c => c.User)
                .WithMany(u => u.CheckInOuts)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Restrict); // 
        }

    }
}
