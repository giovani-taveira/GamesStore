using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application._Service
{
    public class GameService : IGameService
    {
        private readonly IGameRepository repository;
        private readonly IMapper mapper;

        public GameService(IGameRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public List<Games> GetAll()
        {
            var games = repository.GetAll();

            if (games.Count() == 0)
                throw new Exception("Nenhum jogo encontrado!");

            return games.ToList();
        }

        public List<Games> GetByGender(string gender)
        {
            var gameByGender = repository.GetByGender(gender);

            if (gameByGender.Count() == 0)
                throw new Exception("Nenhum jogo encontrado!");

            return gameByGender.ToList();
        }

        public Games GetById(Guid id)
        {
            var game = repository.GetById(id);

            if (game == null)
                throw new Exception("Nenhum jogo encontrado!");

            return game;
        }

        public List<Games> GetByName(string name)
        {
            var gameByName = repository.GetByName(name);

            if (gameByName.Count() == 0)
                throw new Exception("Nenhum jogo encontrado!");

            return gameByName.ToList();
        }

        public List<Games> GetByPrice(decimal price)
        {
            var gameByPrice = repository.GetByPrice(price);

            if (gameByPrice.Count() == 0)
                throw new Exception("Nenhum jogo encontrado!");

            return gameByPrice.ToList();
        }

        public List<Games> GetByReleaseDate(DateTime releaseDate)
        {
            var gameByReleaseDate = repository.GetByReleaseDate(releaseDate);

            if (gameByReleaseDate.Count() == 0)
                throw new Exception("Nenhum jogo encontrado!");

            return gameByReleaseDate.ToList();
        }

        public bool AddNewGame(Guid userId, AddGameInputModel model)
        {
            var nameExists = repository.GetByName(model.name);

            if (nameExists.Count() != 0)
                throw new Exception("Ja existe um jogo com este nome!");

            var game = mapper.Map<Games>(model);
            game.UserId = userId;
            repository.AddGame(game);

            return true;
        }

        public bool DeleteGame(Guid gameId, Guid userId)
        {
            var game = repository.GetById(gameId);

            if (game.UserId != userId)
                throw new Exception("Este usuário não possui nenhum jogo com este ID");

            if (game == null)
                throw new Exception();

            repository.DeleteGame(game);

            return true;
        }
        public bool UpdateGame(Guid gameId, Guid userId, UpdateGameInputModel model)
        {
            var game = repository.GetById(gameId);

            if (game.UserId != userId)
                throw new Exception("Este usuário não possui nenhum jogo com este ID");

            if (game == null)
                throw new Exception();

            game.Update(model.name, model.price, model.description, model.platform, model.publisher);
            repository.UpdateGame(game);

            return true;
        }
    }
}
