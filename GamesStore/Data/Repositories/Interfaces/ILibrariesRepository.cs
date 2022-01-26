using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface ILibrariesRepository
    {
        //Cart ---------------------------------------------------------
        void CreateCart(Cart cart);
        Cart GamesFromCart(int id);
        void AddGameToCart(int id, Games game);
        void RemoveGameFromCart(int userId, int gameId);

        //WishList -----------------------------------------------------
        void CreateWishList(WishList wishList);
        WishList GamesFromWishList(int id);
        void AddGameToWishList(int id, Games game);
        void RemoveGameFromWishList(int userId, int gameId);

        //Library ------------------------------------------------------
        void CreateLibrary(Library library);
        Library GamesFromLibrary(int id);
        void AddGameToLibrary(int id, Games game);
        //void RemoveGameFromLibrary(int userId, int gameId);
    }
}
