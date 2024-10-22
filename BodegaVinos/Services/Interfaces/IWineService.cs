using BodegaVinos.Data.Entities;
using BodegaVinos.Models.DTO;

namespace BodegaVinos.Services.Interfaces
{
    public interface IWineService
    {
        List<Wine> GetWines();
        void CreateWine(CreateWineDTO createWineDTO);
        void AddStockById(int id, int stock);
        void DeleteStockById(int id);
    }
}
