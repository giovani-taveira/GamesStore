using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarrinhoController : ControllerBase
    {
        private readonly IBibliotecasRepository repository;
        private readonly IGameRepository gameRepository;

        public CarrinhoController(IBibliotecasRepository repository, IGameRepository gameRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public IActionResult GetGamesFromCart(int userId)
        {
            var cart = repository.GamesFromCart(userId);  
            return Ok(cart);
        }

        [HttpPost("AdicionarAoCarrinho/{userId}")]
        public IActionResult AddGameOnCart(int userId, int gameId)
        {
            var gameExists = repository.GamesFromCart(userId);
            if (gameExists.Games.Count() != 0)
                return BadRequest("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound();

            repository.AddGameToCart(userId, game);
            return Ok();
        }

        [HttpDelete("RemoverJogoDoCarrinho/{gameId}")]
        public IActionResult RemoveGame(int userId, int gameId)
        {
            repository.RemoveGameFromCart(userId, gameId);
            return NoContent();
        }
    }
}
