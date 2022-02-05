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
    public class LibraryService : ILibraryService
    {
        private readonly ILibrariesRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public LibraryService(ILibrariesRepository repository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }
        public bool AddGame(int userId, int gameId)
        {
            var list = repository.GamesFromLibrary(userId);

            foreach (var _game in list.Games)
                if (_game.GameId == gameId)
                    throw new Exception("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                throw new Exception("Jogo inexistente");

            repository.AddGameToLibrary(userId, game);

            return true;
        }

        public Library GetGames(int userId)
        {
            if (userRepository.GetUserById(userId) == null)
                throw new Exception("Usuário não encontrado");

            var games = repository.GamesFromLibrary(userId);
            return games;
        }
    }
}
