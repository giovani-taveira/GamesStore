using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Games> GetAll();
        Games GetById(int id);
        IEnumerable<Games> GetByName(string nome);
        IEnumerable<Games> GetByGender(string genero);
        IEnumerable<Games> GetByReleaseDate(DateTime dataLancamento);
        IEnumerable<Games> GetByPrice(decimal preco);
        void AddGame(Games game);
        void DeleteGame(Games game);
        void UpdateGame(Games game);
        //void AddComment
    }
}
