using BodegaVinos.Data.Entities;
using BodegaVinos.Models.DTO;

namespace BodegaVinos.Services.Interfaces
{
    public interface ICataService
    {
        public void CreateCata(CreateCataDTO cata);
        public List<Cata> GetCatasByDate();
        public void UpdateGuests(int id,UpdateGuestsDTO guests);
    }
}
