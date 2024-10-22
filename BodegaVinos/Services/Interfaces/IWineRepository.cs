using BodegaVinos.Data.Entities;

namespace BodegaVinos.Services.Interfaces
{
    public interface IWineRepository
    {
        List<Wine> GetWines();
        void UpdateWine(Wine wine);
        void CreateWine(Wine wine);
        Wine GetWineById(int id);
    }
}
