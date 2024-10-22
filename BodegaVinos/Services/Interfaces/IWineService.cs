using BodegaVinos.Data.Entities;
using BodegaVinos.Models.DTO;

namespace BodegaVinos.Services.Interfaces
{
    public interface IWineService
    {
        public List<Wine> GetWines();
        public void CreateWine(CreateWineDTO createWineDTO);
        public void AddStockById(int id, int stock);
        public void RemoveStockById(int id, int stock);
    }
}
