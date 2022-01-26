using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameStoreContext context;

        public GameRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public void AddGame(Games game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }

        public void DeleteGame(Games game)
        {
            context.Games.Remove(game);
            context.SaveChanges();
        }

        public void UpdateGame(Games game)
        {
            context.Games.Update(game);
            context.SaveChanges();
        }

        public IEnumerable<Games> GetAll()
        {
            return context.Games.ToList();
        }

        public IEnumerable<Games> GetByGender(string gender)
        {
            return context.Games.Where(c => c.Gender == gender).ToList();
        }

        public IEnumerable<Games> GetByName(string name)
        {
            return context.Games.Where(c => c.Name == name).ToList();
        }

        public IEnumerable<Games> GetByPrice(decimal price)
        {
            return context.Games.Where(c => c.Price == price).ToList();
        }

        public IEnumerable<Games> GetByReleaseDate(DateTime releaseDate)
        {
            return context.Games.Where(c => c.ReleaseDate == releaseDate).ToList();
        }

        public Games GetById(int id)
        {
            var review =  context.Games.Include(review => review.Reviews).SingleOrDefault(c => c.GameId == id);

            return review;
        }
    }
}
