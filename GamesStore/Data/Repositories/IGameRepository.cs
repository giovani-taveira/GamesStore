using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game GetById(int id);
        IEnumerable<Game> GetByName(string nome);
        IEnumerable<Game> GetByGender(string genero);
        IEnumerable<Game> GetByReleaseDate(DateTime dataLancamento);
        IEnumerable<Game> GetByPrice(decimal preco);
        void AddGame(Game game);
        void DeleteGame(Game game);
        void UpdateGame(Game game);
    }
}
