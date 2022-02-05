using AutoMapper;
using GamesStore.Application.Interface;
using GamesStore.Data.Repositories;
using GamesStore.Entities;
using GamesStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GamesStore.Application._Service
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository repository;
        private readonly IGameRepository gameRepository;
        private readonly IMapper mapper;

        public SaleService(ISaleRepository repository, IGameRepository gameRepository, IMapper mapper)
        {
            this.repository = repository;
            this.gameRepository = gameRepository;
            this.mapper = mapper;
        }

        public bool AddNewSale(int gameId, AddSaleInputModel model)
        {
            var sale = new Sale(gameId, model.promotionalPrice, model.days);

            var TemPromocaoAtiva = repository.TemPromocaoAtiva(gameId);
            var gameQuery = gameRepository.GetById(gameId);

            if (TemPromocaoAtiva)
                throw new Exception("Este jogo ja tem um promoção ativa");

            if (model.promotionalPrice >= gameQuery.Price)
                throw new Exception("O preço promocional não pode ser maior nem igual que o preço normal");

            if (model.days > 30 || model.days < 7)
                throw new Exception("A promoção não pode durar mais que 30 dias e menos que 7 dias");

            gameQuery.ItIsInPromotion = true;
            repository.AddNewSale(sale);

            return true;
        }

        public bool DeleteSale(int saleId)
        {
            var sale = repository.GetSale(saleId);

            if (sale == null)
                throw new Exception();

            var promocao = repository.GetSale(saleId);
            var gameQuery = gameRepository.GetById(promocao.GameId);
            gameQuery.ItIsInPromotion = false;

            repository.DeleteSale(saleId);
            return true;
        }

        public bool DeleteSale()
        {
            var promocoes = repository.GetAllGamesOnSale();
            foreach (var promocao in promocoes)
            {
                if (DateTime.Now >= promocao.PromotionEndDate)
                {
                    var gameQuery = gameRepository.GetById(promocao.GameId);
                    gameQuery.ItIsInPromotion = false;
                    repository.DeleteSale(promocao);
                }
            }
            return true;
        }

        public List<Sale> GetAll()
        {
            var gamesOnSale = repository.GetAllGamesOnSale();

            if (gamesOnSale.Count() == 0)
                throw new Exception("Não há nenhuma promoção no momento");

            return gamesOnSale.ToList();
        }
    }
}
