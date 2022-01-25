﻿using GamesStore.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecasRepository repository;
        private readonly IGameRepository gameRepository;

        public BibliotecaController(IBibliotecasRepository repository, IGameRepository gameRepository)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
        }

        [HttpGet]
        public IActionResult GetGamesFromLibrary(int userId)
        {
            var cart = repository.GamesFromLibrary(userId);
            return Ok(cart);
        }

        [HttpPost("AdicionarABiblioteca/{userId}")]
        public IActionResult AddGameOnLibrary(int userId, int gameId)
        {
            var gameExists = repository.GamesFromLibrary(userId);
            if (gameExists.Games.Count() != 0)
                return BadRequest("Este jogo já está no carrinho");

            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound();

            repository.AddGameToLibrary(userId, game);
            return Ok();
        }

        [HttpDelete("RemoverJogoDoaBiblioteca{gameId}")]
        public IActionResult RemoveGame(int userId, int gameId)
        {
            repository.RemoveGameFromLibrary(userId, gameId);
            return NoContent();
        }
    }
}
