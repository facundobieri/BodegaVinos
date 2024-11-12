using BodegaVinos.Data.Entities;
using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Interfaces;

namespace BodegaVinos.Services.Implementations
{
    public class CataService : ICataService
    {
        private readonly ICataRepository _cataRepository;
        public CataService(ICataRepository cataRepository)
        {
            _cataRepository = cataRepository;
        }
        public void CreateCata(CreateCataDTO createCataDTO)
        {
            var wine = _cataRepository.GetWineById(createCataDTO.WineId);
            var cata = new Cata
            {
                Name = createCataDTO.Name,
                DateTime = createCataDTO.DateTime,
                Wine = wine,
                Guests = createCataDTO.Guests.Select(g => new Guest
                {
                    Name = g.Name,
                    Surname = g.Surname
                }).ToList()
            };
            _cataRepository.CreateCata(cata);
        }

        public List<Cata> GetCatasByDate()
        {
            return _cataRepository.GetCatasByDate();
        }

        public void UpdateGuests(int id,UpdateGuestsDTO guests)
        {
            var cata = _cataRepository.GetCataById(id);
            if (cata == null)
            {
                throw new Exception("Cata not found");
            }
            var newGuests = guests.Guests.Select(g => new Guest
            {
                Name = g.Name,
                Surname = g.Surname
            }).ToList();
        }
    }
}
