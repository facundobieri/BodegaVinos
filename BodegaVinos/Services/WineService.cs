using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;
using BodegaVinos.Models.DTO;

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

        public void RegisterWine(RegisterWineDTO wineData)
        {
            var wine = new Wine
            {
                Id = _wineRepository.Wines.Count + 1,
                Name = wineData.Name,
                Variety = wineData.Variety,
                Year = wineData.Year,
                Region = wineData.Region,
                Stock = wineData.Stock,
                CreatedAt = DateTime.Now
            };
            _wineRepository.Wines.Add(wine);
        }
    }
}
