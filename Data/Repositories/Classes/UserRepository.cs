using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GameStoreContext context;

        public UserRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public void AddUsuario(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUsuario(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public IEnumerable<Games> GetGames(Guid id)
        {
            return context.Games.Where(g => g.UserId == id).ToList();
        }

        public IEnumerable<User> GetAll()
        {
            return context.Users.ToList();
        } 

        public User GetUserById(Guid id)
        {
            return context.Users.Include(c => c.Games).SingleOrDefault(u => u.UserId == id);
        }

        public void UpdateUsuario(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }

        public User GetUsuarioByEmail(string email)
        {
            return context.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUsuarioByNickName(string gamerTag)
        {
            return context.Users.SingleOrDefault(u => u.GamerTag == gamerTag);
        }

        public void AddGames(Games game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }
    }
}
