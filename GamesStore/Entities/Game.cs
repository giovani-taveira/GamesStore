namespace GamesStore.Entities
{
    public class Game
    {
        public int GameId { get; private set; }
        public string Nome { get; private set; }
        public DateTime DataDeLancamento { get; private set; }
        public DateTime CreatedAt { get; set; }
        public decimal Preco { get; private set; }
        public string Genero { get; set; }
        public string Descricao { get; private set; }
        public string Desenvolvedora { get; private set; }
        public string Publisher { get; private set; }
        public string  Plataforma { get; private set; }
        public int ClassificacaoEtaria { get; private set; }
        public bool EstaEmPromocao { get; set; }



        //public Game(string genero)
        //{
        //    Genero = genero;
        //}

        public void Update(
            string nome,
            decimal preco,
            string descricao,
            string publisher,
            string plataforma
            )
        {
            Nome = nome;
            Preco = preco;
            Descricao = descricao;
            Publisher = publisher;
            Plataforma = plataforma;

        }
    }
}
