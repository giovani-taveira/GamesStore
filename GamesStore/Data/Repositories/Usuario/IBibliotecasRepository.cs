using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public interface IBibliotecasRepository
    {
        //Cart ---------------------------------------------------------
        void CreateCart(Carrinho carrinho);
        Carrinho GamesFromCart(int id);
        void AddGameToCart(int id, Games game);
        void RemoveGameFromCart(int userId, int gameId);

        //WishList -----------------------------------------------------
        void CreateWishList(ListaDeDesejos listaDeDesejos);
        ListaDeDesejos GamesFromWishList(int id);
        void AddGameToWishList(int id, Games game);
        void RemoveGameFromWishList(int userId, int gameId);

        //Library ------------------------------------------------------
        void CreateLibrary(Biblioteca biblioteca);
        Biblioteca GamesFromLibrary(int id);
        void AddGameToLibrary(int id, Games game);
        void RemoveGameFromLibrary(int userId, int gameId);
    }
}
