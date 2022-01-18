namespace GamesStore.Entities
{
    public class Games
    {
        public Games()
        {
            CreatedAt = DateTime.Now;  
            Reviews = new List<Review>();
        }

        public int GameId { get; private set; }
        public int UsuarioId { get; set; }
        public string Nome { get; private set; }
        public DateTime DataDeLancamento { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public decimal Preco { get; private set; }
        public string Genero { get; private set; }
        public string Descricao { get; private set; }
        public string Desenvolvedora { get; private set; }
        public string Publisher { get; private set; }
        public string Plataforma { get; private set; }
        public int ClassificacaoEtaria { get; private set; }
        public bool EstaEmPromocao { get; set; }
        public List<Review> Reviews { get; set; }


        internal void AddNewReview(Review review) => Reviews.Add(review);


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
