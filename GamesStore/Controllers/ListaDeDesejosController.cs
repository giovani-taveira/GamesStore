using GamesStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListaDeDesejosController : ControllerBase
    {
        private readonly IBibliotecasRepository repository;
        private readonly IGameRepository gameRepository;

        public ListaDeDesejosController(IBibliotecasRepository repository, IGameRepository gameRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public IActionResult GetGamesFromCart(int userId)
        {
            var cart = repository.GamesFromWishList(userId);
            return Ok(cart);
        }

        [HttpPost("AdicionarNaListaDeDesejos/{userId}")]
        public IActionResult AddGameOnCart(int userId, int gameId)
        {
            var gameExists = repository.GamesFromWishList(userId);
            if (gameExists == null)
                return NotFound();
;
            if (gameExists.Games.Count() != 0)
                return BadRequest("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound();

            repository.AddGameToWishList(userId, game);
            return Ok();
        }

        [HttpDelete("RemoverDaListaDeDesejos/{gameId}")]
        public IActionResult RemoveGame(int userId, int gameId)
        {
            repository.RemoveGameFromWishList(userId, gameId);
            return NoContent();
        }
    }
}
