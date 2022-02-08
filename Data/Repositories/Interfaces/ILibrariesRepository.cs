using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface ILibrariesRepository
    {
        //Cart ---------------------------------------------------------
        void CreateCart(Cart cart);
        Cart GamesFromCart(Guid id);
        void AddGameToCart(Guid id, Games game);
        void RemoveGameFromCart(Guid userId, Guid gameId);

        //WishList -----------------------------------------------------
        void CreateWishList(WishList wishList);
        WishList GamesFromWishList(Guid id);
        void AddGameToWishList(Guid id, Games game);
        void RemoveGameFromWishList(Guid userId, Guid gameId);

        //Library ------------------------------------------------------
        void CreateLibrary(Library library);
        Library GamesFromLibrary(Guid id);
        void AddGameToLibrary(Guid id, Games game);
    }
}
