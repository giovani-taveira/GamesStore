using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreContext context;

        public GameRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public void AddGame(Game game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }

        public void DeleteGame(Game game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
        }

        public void UpdateGame(Game game)
        {
            context.Games.Update(game);
            context.SaveChanges();
        }

        public IEnumerable<Game> GetAll()
        {
            return context.Games.ToList();
        }

        public IEnumerable<Game> GetByGender(string genero)
        {
            return context.Games.Where(c => c.Genero == genero).ToList();
        }

        public IEnumerable<Game> GetByName(string nome)
        {
            return context.Games.Where(c => c.Nome == nome).ToList();
        }

        public IEnumerable<Game> GetByPrice(decimal preco)
        {
            return context.Games.Where(c => c.Preco == preco).ToList();
        }

        public IEnumerable<Game> GetByReleaseDate(DateTime dataLancamento)
        {
            return context.Games.Where(c => c.DataDeLancamento == dataLancamento).ToList();
        }

        public Game GetById(int id)
        {
            return context.Games.Single(c => c.GameId == id);
        }
    }
}
