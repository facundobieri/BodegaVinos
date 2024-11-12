using BodegaVinos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Data
{
    public class BodegaDbContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Cata> Catas { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public BodegaDbContext(DbContextOptions<BodegaDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cata>()
            .HasOne(c => c.Wine)
            .WithMany()
            .HasForeignKey(c => c.WineId);
            modelBuilder.Entity<Cata>()
            .HasMany(c => c.Guests)
            .WithOne(g => g.Cata)
            .HasForeignKey(g => g.CataId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
