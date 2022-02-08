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
        User GetUserById(Guid id);
        IEnumerable<Games> GetGames(Guid id);
        User GetUsuarioByEmail(string email);
        User GetUsuarioByNickName(string gamerTag);
    }
}
