using GamesStore.Entities;
namespace GamesStore.Data.Repositories
{
    public interface IUserRepository
    {
        void AddUsuario(User usuario);
        void UpdateUsuario(User usuario);
        void DeleteUsuario(User usuario);
        void AddGames(Games game);
        IEnumerable<User> GetAll();
        User GetUserById(int id);
        IEnumerable<Games> GetGames(int id);
        User GetUsuarioByEmail(string email);
        User GetUsuarioByNickName(string gamerTag);
    }
}
