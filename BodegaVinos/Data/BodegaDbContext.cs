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
            // Relación muchos a muchos entre Cata y Wine
            modelBuilder.Entity<Cata>()
                .HasMany(c => c.wines)  // Una Cata puede tener muchos Wines
                .WithMany(w => w.catas);  // Un Wine puede estar en muchas Catas

            // Relación uno a muchos entre Cata y Guest
            modelBuilder.Entity<Cata>()
                .HasMany(c => c.guests)  // Una Cata puede tener muchos Guests
                .WithOne(g => g.Cata)  // Cada Guest pertenece a una Cata
                .HasForeignKey(g => g.CataId);  // El FK está en Guest

            base.OnModelCreating(modelBuilder);
        }
    }
}
