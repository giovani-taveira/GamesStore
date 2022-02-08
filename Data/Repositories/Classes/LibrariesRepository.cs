using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data.Repositories
{
    public class LibrariesRepository : ILibrariesRepository
    {
        private readonly GameStoreContext context;

        public LibrariesRepository(GameStoreContext context)
        {
            this.context = context;
        }
        #region Cart
        public void CreateCart(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        public Cart GamesFromCart(Guid id)
        {
            return context.Carts.Include(c => c.Games).SingleOrDefault(c => c.UserId == id);  
        }

        public void AddGameToCart(Guid id, Games game)
        {
            var games = context.Carts.Single(c => c.UserId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }

        public void RemoveGameFromCart(Guid userId, Guid gameId)
        {
            var user = context.Carts.Include(c => c.Games).SingleOrDefault(c => c.UserId == userId);
            var game = user.Games.SingleOrDefault(c => c.GameId == gameId);
            user.Games.Remove(game);
            context.SaveChanges();
        }
        #endregion

        #region WishList
        public void CreateWishList(WishList wishList)
        {
            context.WishLists.Add(wishList);
            context.SaveChanges();
        }

        public WishList GamesFromWishList(Guid id)
        {
            return context.WishLists.Include(c => c.Games).SingleOrDefault(c => c.UserId == id);
        }

        public void AddGameToWishList(Guid id, Games game)
        {
            var games = context.WishLists.Single(c => c.UserId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }

        public void RemoveGameFromWishList(Guid userId, Guid gameId)
        {
            var user = context.WishLists.Include(c => c.Games).SingleOrDefault(c => c.UserId == userId);
            var game = user.Games.SingleOrDefault(c => c.GameId == gameId);
            user.Games.Remove(game);
            context.SaveChanges();
        }
        #endregion

        #region Library
        public void CreateLibrary(Library library)
        {
            context.Libraries.Add(library);
            context.SaveChanges();
        }

        public Library GamesFromLibrary(Guid id)
        {
            return context.Libraries.Include(c => c.Games).SingleOrDefault(c => c.UserId == id);
        }

        public void AddGameToLibrary(Guid id, Games game)
        {
            var games = context.Libraries.Single(c => c.UserId == id);
            games.Games.Add(game);
            context.SaveChanges();
        }
        #endregion
    }
}
