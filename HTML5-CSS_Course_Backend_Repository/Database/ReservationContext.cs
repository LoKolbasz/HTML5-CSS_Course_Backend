using HTML5_CSS_Course_Backend_Models;
using Microsoft.EntityFrameworkCore;

namespace HTML5_CSS_Course_Backend_Repository.Database
{
    public class ReservationContext : DbContext
    {
        public DbSet<Table> ? tables { get; set; }
        public DbSet<Reservation> ? reservations { get; set; }
        public ReservationContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Reservation>(r => r
                                            .HasOne(t => t.table)
                                            .WithMany(t => t.reservations)
                                            .HasForeignKey(t => t.tableId)
                                            .OnDelete(DeleteBehavior.SetNull));
            modelBuilder.Entity<Table>(t => t
                                      .HasMany(r => r.reservations)
                                      .WithOne(r => r.table)
                                      .HasForeignKey(r => r.tableId)
                                      .OnDelete(DeleteBehavior.SetNull));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("reservations");
            }
        }
    }
}