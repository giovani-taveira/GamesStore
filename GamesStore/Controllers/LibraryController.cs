using GamesStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibrariesRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public LibraryController(ILibrariesRepository repository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetGamesFromLibrary(int userId)
        {
            if (userRepository.GetUserById(userId) == null) 
                return NotFound();

            var cart = repository.GamesFromLibrary(userId);
            return Ok(cart);
        }

        [HttpPost("AddToLibrary/{userId}/{gameId}")]
        public IActionResult AddGameOnLibrary(int userId, int gameId)
        {
            if (userRepository.GetUserById(userId) == null)
                return NotFound("Usuário não encontrado");

            var list = repository.GamesFromLibrary(userId);

            foreach(var _game in list.Games)
                if (_game.GameId == gameId)
                    return BadRequest("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound();

            repository.AddGameToLibrary(userId, game);
            return Ok(game);
        }

        //[HttpDelete("RemoveFromLibrary/{gameId}")]
        //public IActionResult RemoveGame(int userId, int gameId)
        //{
        //    if (userRepository.GetUserById(userId) == null)
        //        return NotFound("Usuário não encontrado");

        //    if (gameRepository.GetById(gameId) == null)
        //        return NotFound("Jogo não encontrado");

        //    repository.RemoveGameFromLibrary(userId, gameId);
        //    return NoContent();
        //}
    }
}
