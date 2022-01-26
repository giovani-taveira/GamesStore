using GamesStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WishListController : ControllerBase
    {
        private readonly ILibrariesRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public WishListController(ILibrariesRepository repository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetGamesFromWishList(int userId)
        {
            if (userRepository.GetUserById(userId) == null)
                return NotFound();

            var cart = repository.GamesFromWishList(userId);
            return Ok(cart);
        }

        [HttpPost("AdicionarNaListaDeDesejos/{userId}/{gameId}")]
        public IActionResult AddGameOnWishList(int userId, int gameId)
        {
            var list = repository.GamesFromCart(userId);

            foreach (var _game in list.Games)
                if (_game.GameId == gameId)
                    return BadRequest("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound();

            repository.AddGameToWishList(userId, game);
            return Ok(game);
        }

        [HttpDelete("RemoverDaListaDeDesejos/{userId}/{gameId}")]
        public IActionResult RemoveGame(int userId, int gameId)
        {
            if (userRepository.GetUserById(userId) == null)
                return NotFound("Usuário não encontrado");

            if (gameRepository.GetById(gameId) == null)
                return NotFound("Jogo não encontrado");

            repository.RemoveGameFromWishList(userId, gameId);
            return NoContent();
        }
    }
}
