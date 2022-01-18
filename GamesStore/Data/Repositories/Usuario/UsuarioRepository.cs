using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly GameStoreContext context;

        public UsuarioRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public void AddUsuario(Usuario usuario)
        {
            context.Usuarios.Add(usuario);
            context.SaveChanges();
        }

        public void DeleteUsuario(Usuario usuario)
        {
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
        }

        public IEnumerable<Games> GetGames(int id)
        {
            return context.Games.Where(g => g.UsuarioId == id).ToList();
        }

        public IEnumerable<Usuario> GetAll()
        {
            return context.Usuarios.ToList();
        } 

        public Usuario GetUserById(int id)
        {
            return context.Usuarios.Include(c => c.Games).SingleOrDefault(u => u.UsuarioId == id);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            context.Usuarios.Update(usuario);
            context.SaveChanges();
        }

        public Usuario GetUsuarioByEmail(string email)
        {
            return context.Usuarios.SingleOrDefault(u => u.Email == email);
        }

        public Usuario GetUsuarioByNickName(string nickName)
        {
            return context.Usuarios.SingleOrDefault(u => u.NickName == nickName);
        }

        public void AddGames(Games game)
        {
            context.Games.Add(game);
            context.SaveChanges();
        }
    }
}
