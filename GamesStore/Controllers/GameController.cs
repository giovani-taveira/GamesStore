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

        [HttpGet("GetByName/{nome}")]
        public IActionResult GetByName(string nome)
        {
            var gameByName = repository.GetByName(nome);

            if (gameByName.Count() == 0)
                return NotFound();

            return Ok(gameByName);
        }

        [HttpGet("GetByGender/{genero}")]
        public IActionResult GetByGender(string genero)
        {
            var gameByGender = repository.GetByGender(genero);

            if(gameByGender.Count() == 0)
                return NotFound();

            return Ok(gameByGender);
        }

        [HttpGet("GetByReleaseDate/{dataLancamento}")]
        public IActionResult GetByReleaseDate(DateTime dataDeLancamento)
        {
            var gameByReleaseDate = repository.GetByReleaseDate(dataDeLancamento);

            if (gameByReleaseDate.Count() == 0)
                return NotFound();

            return Ok(gameByReleaseDate);
        }

        [HttpGet("GetByPrice/{preco}")]
        public IActionResult GetByPrice(decimal preco)
        {
            var gameByPrice = repository.GetByPrice(preco);

            if (gameByPrice.Count() == 0)
                return NotFound();

            return Ok(gameByPrice);
        }

        [HttpPost]
        public IActionResult AddNewGame(AddGameInputModel model)
        {
            var game = mapper.Map<Game>(model);
            game.CreatedAt = DateTime.Now;
            
            repository.AddGame(game);

            return CreatedAtAction("Game ID", new { id = game.GameId }, game);
        }

        [HttpPut]
        public IActionResult UpdateGame(int id, UpdateGameInputModel model)
        {
            var game = repository.GetById(id);

            if (game == null)
                return NotFound();

            game.Update(model.nome, model.preco, model.descricao, model.plataforma, model.publisher);
            repository.UpdateGame(game);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult DeleteGame(int id)
        {
            var game = repository.GetById(id);

            if (game == null)
                return NotFound();

            repository.DeleteGame(game);

            return NoContent();
        }
    }
}
