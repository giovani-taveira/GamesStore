using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository repository;
        private readonly IMapper mapper;

        public GameController(IGameRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var games = repository.GetAll();

            if(games.Count() == 0)
                return NotFound();

            return Ok(games);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetAll(int id)
        {
            var games = repository.GetById(id);

            if (games == null)
                return NotFound();

            return Ok(games);
        }

        [HttpGet("GetByName/{name}")]
        public IActionResult GetByName(string name)
        {
            var gameByName = repository.GetByName(name);

            if (gameByName.Count() == 0)
                return NotFound();

            return Ok(gameByName);
        }

        [HttpGet("GetByGender/{gender}")]
        public IActionResult GetByGender(string gender)
        {
            var gameByGender = repository.GetByGender(gender);

            if(gameByGender.Count() == 0)
                return NotFound();

            return Ok(gameByGender);
        }

        /// <remarks>
        /// ReleaseDate Format : yyyy-MM-ddT00:00:00
        /// </remarks>
        [HttpGet("GetByReleaseDate/{releaseDate}")]
        public IActionResult GetByReleaseDate(DateTime releaseDate)
        {
            var gameByReleaseDate = repository.GetByReleaseDate(releaseDate);

            if (gameByReleaseDate.Count() == 0)
                return NotFound();

            return Ok(gameByReleaseDate);
        }

        [HttpGet("GetByPrice/{price}")]
        public IActionResult GetByPrice(decimal price)
        {
            var gameByPrice = repository.GetByPrice(price);

            if (gameByPrice.Count() == 0)
                return NotFound();

            return Ok(gameByPrice);
        }


        /// <remarks>
        /// ReleaseDate Format : dd/MM/yyyy
        /// </remarks>
        [HttpPost("{userId}")]
        public IActionResult AddNewGame(int userId, AddGameInputModel model)
        {
            var nameExists = repository.GetByName(model.name);

            if (nameExists.Count() != 0)
                return BadRequest("Ja existe um jogo com este nome!");

            var game = mapper.Map<Games>(model);
            game.UserId = userId;
            repository.AddGame(game);

            return CreatedAtAction("Game ID", new { GameId = game.GameId }, game);
        }

        [HttpPut("{gameId}/{userId}")]
        public IActionResult UpdateGame(int gameId,int userId, UpdateGameInputModel model)
        {
            var game = repository.GetById(gameId);

            if (game.UserId != userId)
                return NotFound("Este usuário não possui nenhum jogo com este ID");

            if (game == null)
                return NotFound();

            game.Update(model.name, model.price, model.description, model.platform, model.publisher);
            repository.UpdateGame(game);

            return NoContent();
        }

        [HttpDelete("{gameId}/{userId}")]
        public IActionResult DeleteGame(int gameId, int userId)
        {
            var game = repository.GetById(gameId);

            if (game.UserId != userId)
                return NotFound("Este usuário não possui nenhum jogo com este ID");

            if (game == null)
                return NotFound();

            repository.DeleteGame(game);

            return NoContent();
        }
    }
}
