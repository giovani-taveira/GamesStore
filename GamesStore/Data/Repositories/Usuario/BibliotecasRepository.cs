using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data.Repositories
{
    public class BibliotecasRepository : IBibliotecasRepository
    {
        private readonly GameStoreContext context;

        public BibliotecasRepository(GameStoreContext context)
        {
            this.context = context;
        }
        #region Cart
        public void CreateCart(Carrinho carrinho)
        {
            context.Carrinhos.Add(carrinho);
            context.SaveChanges();
        }

        public Carrinho GamesFromCart(int id)
        {
            return context.Carrinhos.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == id);  
        }

        public void AddGameToCart(int id, Games game)
        {
            var games = context.Carrinhos.Single(c => c.UsuarioId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }

        public void RemoveGameFromCart(int userId, int gameId)
        {
            var user = context.Carrinhos.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == userId);
            var game = user.Games.SingleOrDefault(c => c.GameId == gameId);
            user.Games.Remove(game);
            context.SaveChanges();
        }
        #endregion

        #region WishList
        public void CreateWishList(ListaDeDesejos listaDeDesejos)
        {
            context.ListaDeDesejos.Add(listaDeDesejos);
            context.SaveChanges();
        }

        public ListaDeDesejos GamesFromWishList(int id)
        {
            return context.ListaDeDesejos.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == id);
        }

        public void AddGameToWishList(int id, Games game)
        {
            var games = context.ListaDeDesejos.Single(c => c.UsuarioId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }

        public void RemoveGameFromWishList(int userId, int gameId)
        {
            var user = context.ListaDeDesejos.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == userId);
            var game = user.Games.SingleOrDefault(c => c.GameId == gameId);
            user.Games.Remove(game);
            context.SaveChanges();
        }
        #endregion

        #region Library
        public void CreateLibrary(Biblioteca biblioteca)
        {
            context.Bibliotecas.Add(biblioteca);
            context.SaveChanges();
        }

        public Biblioteca GamesFromLibrary(int id)
        {
            return context.Bibliotecas.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == id);
        }

        public void AddGameToLibrary(int id, Games game)
        {
            var games = context.Bibliotecas.Single(c => c.UsuarioId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }

        public void RemoveGameFromLibrary(int userId, int gameId)
        {
            var user = context.Bibliotecas.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == userId);
            var game = user.Games.SingleOrDefault(c => c.GameId == gameId);
            user.Games.Remove(game);
            context.SaveChanges();
        }
        #endregion
    }
}
