using DefenseSim.Models;
using Microsoft.EntityFrameworkCore;

namespace DefenseSim.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Weapon> weapons {get; set;}
        public DbSet<Response> responses {get; set;}
        public DbSet<Threat> threats { get; set; }
        public DbSet<Inventory> inventory {get; set;}
        public DbSet<Location> locations {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Weapon>()
                .Property(w => w.Type)
                .IsRequired();
            modelBuilder.Entity<Weapon>()
                .Property(w => w.CounterMeasure)
                .IsRequired();
            modelBuilder.Entity<Weapon>()
                .HasKey(w => w.Id);

            modelBuilder.Entity<Inventory>()
                .Property(i => i.MeasureType)
                .IsRequired();

            modelBuilder.Entity<Location>()
                .Property(i => i.Name)
                .IsRequired()
                .IsUnicode(true);

            // קישורים מהאיום לשאר המודלים
            modelBuilder.Entity<Threat>()
                .HasOne(t => t.Weapon)
                .WithMany()
                .HasForeignKey(t => t.WeaponId);
            modelBuilder.Entity<Threat>()
                .HasOne(t => t.Origin)
                .WithMany()
                .HasForeignKey(t => t.OriginId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Threat>()
                .HasOne(t => t.Destination)
                .WithMany()
                .HasForeignKey(t => t.DestinationId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Threat>()
                .HasOne(t => t.Response)
                .WithMany()
                .HasForeignKey(t => t.ResponseId);

        }
    }
}
