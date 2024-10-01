using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;

namespace BodegaVinos.Services
{
    public class WineService
    {
        private readonly WineRepository _wineRepository;
        public WineService(WineRepository wineRepository) {
            _wineRepository = wineRepository;
        }

        public List<Wine> GetWines()
        {
            return _wineRepository.Wines;
        }
    }
}
