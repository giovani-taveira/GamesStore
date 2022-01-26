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
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;

        public SaleController(ISaleRepository repository, IGameRepository gameRepository, IMapper mapper)
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
        public IActionResult AddNewSale(int gameId, AddSaleInputModel model)
        {
            var sale = new Sale(gameId, model.promotionalPrice, model.days);

            var TemPromocaoAtiva = repository.TemPromocaoAtiva(gameId);
            var gameQuery = gameRepository.GetById(gameId);
            if (TemPromocaoAtiva)
                return BadRequest("Este jogo ja tem um promoção ativa");

            if (model.promotionalPrice >= gameQuery.Price)
                return BadRequest("O preço promocional não pode ser maior nem igual que o preço normal");

            if (model.days > 30 || model.days < 7)
                return BadRequest("A promoção não pode durar mais que 30 dias e menos que 7 dias");



            gameQuery.ItIsInPromotion = true;
            repository.AddNewSale(sale);

            return CreatedAtAction("Promocao ID", new { id = sale.SaleId}, sale);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSale(int id)
        {
            var sale = repository.GetSale(id);

            if (sale == null)
                return NotFound();

            var promocao = repository.GetSale(id);
            var gameQuery = gameRepository.GetById(promocao.GameId);
            gameQuery.ItIsInPromotion = false;

            repository.DeleteSale(id);
            return NoContent();
        }

        /// <remarks>
        /// Promoçao é deletada se tiver passado da data limite de duração
        /// </remarks>
        [HttpDelete]
        public async Task<IActionResult> DeleteSale()
        {
            var promocoes = repository.GetAllGamesOnSale(); 
            foreach (var promocao in promocoes)
            {
                if(DateTime.Now >= promocao.PromotionEndDate)
                {
                    var gameQuery = gameRepository.GetById(promocao.GameId);
                    gameQuery.ItIsInPromotion = false;
                    repository.DeleteSale(promocao);
                }
            }
            return NoContent();
        }
    }
}
