using GamesStore.Entities;

namespace GamesStore.Data.Repositories
{
    public class PromocaoRepository : IPromocaoRepository
    {
        private readonly GameStoreContext context;

        public PromocaoRepository(GameStoreContext context)
        {
            this.context = context;
        }

        public void AddNewSale(Promocao promocao)
        {
            context.Promocao.Add(promocao);
            context.SaveChanges();
        }

        public void DeleteSale(int id)
        {
            var promocao = context.Promocao.Single(c => c.PromocaoId == id);
            context.Promocao.Remove(promocao);
            context.SaveChanges();
        }
        public void DeleteSale(Promocao promocao)
        {
            context.Promocao.Remove(promocao);
            context.SaveChanges();
        }

        public IEnumerable<Promocao> GetAllGamesOnSale()
        {
            return context.Promocao.ToList();
        }

        public Promocao GetSale(int id)
        {
            return context.Promocao.SingleOrDefault(c => c.PromocaoId == id);
        }

        public bool TemPromocaoAtiva(int gameId)
        {
            var ctx = context.Promocao.SingleOrDefault(c => c.GameId == gameId);
            if (ctx != null)
                return true;
            else
                return false;
        }
    }
}
