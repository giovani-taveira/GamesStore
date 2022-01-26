using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        private readonly ILibrariesRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IUserRepository userRepository;

        public CartController(ILibrariesRepository repository, IGameRepository gameRepository, IUserRepository userRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.userRepository = userRepository;
        }

        [HttpGet("{userId}")]
        public IActionResult GetGamesFromCart(int userId)
        {
            if (userRepository.GetUserById(userId) == null)
                return NotFound();

            var cart = repository.GamesFromCart(userId);  
            return Ok(cart);
        }

        [HttpPost("AddToCart/{userId}/{gameId}")]
        public IActionResult AddGameOnCart(int userId, int gameId)
        {
            var list = repository.GamesFromCart(userId);

            foreach (var _game in list.Games)
                if (_game.GameId == gameId)
                    return BadRequest("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound("Jogo inexistente");

            repository.AddGameToCart(userId, game);
            return Ok(game);
        }

        [HttpDelete("RemoveFromCart/{userId}/{gameId}")]
        public IActionResult RemoveGame(int userId, int gameId)
        {
            if (userRepository.GetUserById(userId) == null)
                return NotFound("Usuário não encontrado");

            if (gameRepository.GetById(gameId) == null)
                return NotFound("Jogo não encontrado");

            repository.RemoveGameFromCart(userId, gameId);
            return NoContent();
        }
    }
}
