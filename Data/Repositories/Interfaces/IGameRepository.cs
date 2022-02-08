using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Games> GetAll();
        Games GetById(Guid id);
        IEnumerable<Games> GetByName(string name);
        IEnumerable<Games> GetByGender(string gender);
        IEnumerable<Games> GetByReleaseDate(DateTime releaseDate);
        IEnumerable<Games> GetByPrice(decimal price);
        void AddGame(Games game);
        void DeleteGame(Games game);
        void UpdateGame(Games game);
    }
}
