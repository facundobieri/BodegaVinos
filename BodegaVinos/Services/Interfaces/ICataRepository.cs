using BodegaVinos.Data.Entities;
using BodegaVinos.Models.DTO;

namespace BodegaVinos.Services.Interfaces
{
    public interface ICataRepository
    {
        public Cata GetCataById(int id);
        public void CreateCata(Cata cata);
        public List<Cata> GetCatasByDate();
        public void UpdateGuests(Cata cata, List<Guest> guests);
        public Wine GetWineById(int id);
    }
}
