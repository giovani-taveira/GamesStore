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

        public Carrinho GamesFromCart(int id)
        {
            return context.Carrinhos.Include(c => c.Games).SingleOrDefault(c => c.UsuarioId == id);  
        }

        public IEnumerable<Games> GamesFromLibrary(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Games> GamesFromWishList(int id)
        {
            throw new NotImplementedException();
        }

        public void AddGameToCart(int id, Games game)
        {
            var games = context.Carrinhos.Single(c => c.UsuarioId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }

        public void AddGameToLibrary(Games game)
        {
            throw new NotImplementedException();
        }

        public void AddGameToWishList(Games game)
        {
            throw new NotImplementedException();
        }

        public void RemoveGameFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveGameFromLibrary(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveGameFromWishList(int id)
        {
            throw new NotImplementedException();
        }

        public void CreateCart(Carrinho carrinho)
        {
            context.Carrinhos.Add(carrinho);
            context.SaveChanges();
        }
    }
}
