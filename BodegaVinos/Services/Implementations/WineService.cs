using BodegaVinos.Data.Entities;
using BodegaVinos.Data.Repository;
using BodegaVinos.Models.DTO;
using BodegaVinos.Services.Interfaces;

namespace BodegaVinos.Services.Implementations
{
    public class WineService : IWineService
    {
        private readonly WineRepository _wineRepository;
        public WineService(WineRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }

        public List<Wine> GetWines()
        {
            return _wineRepository.GetWines();
        }
        public void CreateWine(CreateWineDTO createWineDTO)
        {
            var wine = new Wine
            {
                Name = createWineDTO.Name,
                Variety = createWineDTO.Variety,
                Year = createWineDTO.Year,
                Region = createWineDTO.Region,
                Stock = createWineDTO.Stock,
                CreatedAt = DateTime.Now
            };
            _wineRepository.CreateWine(wine);
        }
        public void AddStockById(int id, int stock)
        {
            var wine = _wineRepository.GetWineById(id);
            if (wine == null)
                            {
                throw new Exception("Wine not found");
            } else
            {
                wine.AddStock(stock);
                _wineRepository.UpdateWine(wine);
            }
        }
        public void RemoveStockById(int id, int stock) 
        { 
            var wine = _wineRepository.GetWineById(id);
            if (wine == null)
            {
                throw new Exception("Wine not found");
            } else
            {
                wine.RemoveStock(stock);
                _wineRepository.UpdateWine(wine);
            }
        }
    }
}
