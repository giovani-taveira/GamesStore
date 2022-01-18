using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IPromocaoRepository
    {
        IEnumerable<Promocao> GetAllGamesOnSale();
        Promocao GetSale(int id);
        void AddNewSale(Promocao promocao);
        void DeleteSale(int id);
        void DeleteSale(Promocao promocao);
        bool TemPromocaoAtiva(int gameId);
    }
}
