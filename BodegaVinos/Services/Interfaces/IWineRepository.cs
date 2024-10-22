using BodegaVinos.Data.Entities;

namespace BodegaVinos.Services.Interfaces
{
    public interface IWineRepository
    {
        public List<Wine> GetWines();
        public void UpdateWine(Wine wine);
        public void CreateWine(Wine wine);
        public Wine GetWineById(int id);
        public List<Wine> GetWinesByVariety(string variety);
    }
}
