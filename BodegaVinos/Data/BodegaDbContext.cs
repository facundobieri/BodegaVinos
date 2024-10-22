using BodegaVinos.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Data
{
    public class BodegaDbContext : DbContext
    {
        public DbSet<Wine> Wines { get; set; }
        public DbSet<User> Users { get; set; }
        public BodegaDbContext(DbContextOptions<BodegaDbContext> options) : base(options)
        {
        }
    }
}
