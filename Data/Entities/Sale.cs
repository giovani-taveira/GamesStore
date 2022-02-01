using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GamesStore.Entities
{
    public class Sale
    {
        public Sale()
        {
            PromotionStartDate = DateTime.Now;
        }

        public Sale(int gameId, decimal price, int dias)
        {
            GameId = gameId;
            PromotionalPrice = price;
            PromotionEndDate = DateTime.Now.AddDays(dias);
        }

        public int SaleId { get; private set; }
        public int GameId { get; private set; }
        public decimal PromotionalPrice { get; private set; }
        public DateTime PromotionStartDate { get; private set; } 
        public DateTime PromotionEndDate { get; private set; } 
    }
}
