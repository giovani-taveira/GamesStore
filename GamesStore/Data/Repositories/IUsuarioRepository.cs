using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IUsuarioRepository
    {
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(Usuario usuario);
        void AddGames(Game game);
        IEnumerable<Usuario> GetAll();
        Usuario GetUserById(int id);
        IEnumerable<Game> GetGames(int id);
        Usuario GetUsuarioByEmail(string email);
        Usuario GetUsuarioByNickName(string nickName);

    }
}
