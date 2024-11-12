using BodegaVinos.Data.Entities;
using BodegaVinos.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BodegaVinos.Data.Repositories
{
    public class CataRepository : ICataRepository
    {
        private readonly BodegaDbContext _context;
        public CataRepository(BodegaDbContext context)
        {
            _context = context;
        }

        public Cata GetCataById(int id)
        {
            return _context.Catas
                .Include(c => c.Wine)
                .Include(c => c.Guests)
                .FirstOrDefault(c => c.Id == id);
        }

        public void CreateCata(Cata cata)
        {
            _context.Catas.Add(cata);
            _context.SaveChanges();
        }

        public List<Cata> GetCatasByDate()
        {
            return _context.Catas
                .Include(c => c.Wine)
                .Include(c => c.Guests)
                .Where(c => c.DateTime.Date > DateTime.Now.Date)
                .ToList();
        }
        public void UpdateGuests(Cata cata, List<Guest> guests)
        {
            cata.Guests.AddRange(guests);
            _context.SaveChanges();
        }
        public Wine GetWineById(int id)
        {
            return _context.Wines.FirstOrDefault(w => w.Id == id);
        }
    }
}
