using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetAllGamesOnSale();
        Sale GetSale(Guid id);
        void AddNewSale(Sale sale);
        void DeleteSale(Guid id);
        void DeleteSale(Sale sale);
        bool TemPromocaoAtiva(Guid gameId);
    }
}
