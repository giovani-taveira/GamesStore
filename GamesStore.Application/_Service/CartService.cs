using GamesStore.Application.Interface;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application._Service
{
    public class CartService : ICartService
    {
        private readonly ILibrariesRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public CartService(ILibrariesRepository repository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }
        public bool AddGame(Guid userId, Guid gameId)
        {
            var list = repository.GamesFromCart(userId);

            foreach (var _game in list.Games)
                if (_game.GameId == gameId)
                    throw new Exception("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                throw new Exception("Jogo inexistente");

            repository.AddGameToCart(userId, game);

            return true;
        }

        public Cart GetGames(Guid userId)
        {
            if (userRepository.GetUserById(userId) == null)
                throw new Exception("Usuário não encontrado");

            var games = repository.GamesFromCart(userId);
            return games;
        }

        public bool RemoveGame(Guid userId, Guid gameId)
        {
            if (userRepository.GetUserById(userId) == null)
                throw new Exception("Usuário não encontrado");

            if (gameRepository.GetById(gameId) == null)
                throw new Exception("Jogo não encontrado");

            repository.RemoveGameFromCart(userId, gameId);

            return true;
        }
    }
}
