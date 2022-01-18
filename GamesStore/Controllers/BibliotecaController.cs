using AutoMapper;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private readonly IBibliotecasRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;

        public BibliotecaController(IBibliotecasRepository repository, IGameRepository gameRepository, IMapper mapper)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetGamesFromCart(int userId)
        {
            var cart = repository.GamesFromCart(userId);  
            return Ok(cart);
        }


        [HttpPost("/AdicionarAoCarrinho")]
        public IActionResult AddGameOnCart(int userId, int gameId)
        {
            var game = gameRepository.GetById(gameId);
            if (game == null)
                return NotFound();

            repository.AddGameToCart(userId, game);
            return Ok();
        }

        [HttpPost()]
        public IActionResult CreateCart(int id, AddCarrinhoInputModel model)
        {

            var cart = mapper.Map<Carrinho>(model);
            repository.CreateCart(cart);
            return Ok();
        }
    }
}
