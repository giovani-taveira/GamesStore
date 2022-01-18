using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IBibliotecasRepository
    {
        void CreateCart(Carrinho carrinho);
        Carrinho GamesFromCart(int id);
        IEnumerable<Games> GamesFromWishList(int id);
        IEnumerable<Games> GamesFromLibrary(int id);
        void AddGameToCart(int id, Games game);
        void RemoveGameFromCart(int id);
        void AddGameToLibrary(Games game);
        void RemoveGameFromLibrary(int id);
        void AddGameToWishList(Games game);
        void RemoveGameFromWishList(int id);


    }
}
