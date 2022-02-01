using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllGamesOnSale();
        Sale GetSale(int id);
        void AddNewSale(Sale sale);
        void DeleteSale(int id);
        void DeleteSale(Sale sale);
        bool TemPromocaoAtiva(int gameId);
    }
}
