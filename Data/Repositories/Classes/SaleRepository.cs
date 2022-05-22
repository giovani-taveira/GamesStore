using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly GameStoreContext context;

        public SaleRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public void AddNewSale(Sale sale)
        {
            context.Sales.Add(sale);
            context.SaveChanges();
        }

        public void DeleteSale(Guid id)
        {
            var promocao = context.Sales.Single(c => c.SaleId == id);
            context.Sales.Remove(promocao);
            context.SaveChanges();
        }
        public void DeleteSale(Sale sale)
        {
            context.Sales.Remove(sale);
            context.SaveChanges();
        }

        public IEnumerable<Sale> GetAllGamesOnSale()
        {
            return context.Sales.ToList();
        }

        public Sale GetSale(Guid id)
        {
            return context.Sales.SingleOrDefault(c => c.SaleId == id);
        }

        public bool TemPromocaoAtiva(Guid gameId)
        {
            var ctx = context.Sales.SingleOrDefault(c => c.GameId == gameId);
            if (ctx != null)
                return true;
            else
                return false;
        }
    }
}
