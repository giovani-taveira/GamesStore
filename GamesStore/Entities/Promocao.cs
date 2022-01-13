using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace GamesStore.Entities
{
    public class Promocao
    {
        //public Promocao(int gameId, decimal precoPromocional, int dias)
        //{
        //    GameId = gameId;
        //    PrecoPromocional = precoPromocional;
        //    DataInicialDaPromocao = DateTime.Now;
        //    DataFinalDaPromocao = DateTime.Now.AddDays(dias);
        //}

        public int PromocaoId { get; set; }
        public int GameId { get; set; }
        public decimal PrecoPromocional { get; set; }
        public DateTime DataInicialDaPromocao { get; set; } 
        public DateTime DataFinalDaPromocao { get; set; } 
    }
}
