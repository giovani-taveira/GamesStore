using AutoMapper;
using GamesStore.Data;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace GamesStore.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PromocaoController : ControllerBase
    {
        private readonly IPromocaoRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;

        public PromocaoController(IPromocaoRepository repository, IGameRepository gameRepository, IMapper mapper)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var gamesOnSale = repository.GetAllGamesOnSale();

            if (gamesOnSale.Count() == 0)
                return NotFound("Não há nenhuma promoção no momento");

            return Ok(gamesOnSale);
        }

        [HttpPost("{gameId}")]
        public IActionResult AddNewSale(int gameId, AddPromocaoInputModel model)
        {
            var sale = mapper.Map<Promocao>(model);

            sale.DataFinalDaPromocao = DateTime.Now.AddDays(model.Dias);
            sale.PrecoPromocional = model.PrecoPromocao;
            sale.GameId = gameId;

            var TemPromocaoAtiva = repository.TemPromocaoAtiva(gameId);
            var gameQuery = gameRepository.GetById(gameId);
            if (TemPromocaoAtiva)
                return BadRequest("Este jogo ja tem um promoção ativa");

            if (model.PrecoPromocao >= gameQuery.Preco)
                return BadRequest("O preço promocional não pode ser maior nem igual que o preço normal");

            if (model.Dias > 30 || model.Dias < 7)
                return BadRequest("A promoção não pode durar mais que 30 dias e menos que 7 dias");

            //var sale = new Promocao(gameId, model.PrecoPromocao, model.Dias);

            gameQuery.EstaEmPromocao = true;
            repository.AddNewSale(sale);

            return CreatedAtAction("Promocao ID", new { id = sale.PromocaoId }, sale);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = repository.GetSale(id);

            if (sale == null)
                return NotFound();

            var promocao = repository.GetSale(id);
            var gameQuery = gameRepository.GetById(promocao.GameId);
            gameQuery.EstaEmPromocao = false;

            repository.DeleteSale(id);
            return NoContent();
        }

        [HttpDelete()]
        public IActionResult DeleteSale()
        {
            var promocoes = repository.GetAllGamesOnSale(); 
            foreach (var promocao in promocoes)
            {
                if(DateTime.Now >= promocao.DataFinalDaPromocao)
                {
                    var gameQuery = gameRepository.GetById(promocao.GameId);
                    gameQuery.EstaEmPromocao = false;
                    repository.DeleteSale(promocao);
                }
            }
            return NoContent();
        }
    }
}
