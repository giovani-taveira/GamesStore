namespace GamesStore.Entities
{
    public class Games
    {
        public Games()
        {
            CreatedAt = DateTime.Now;  
            Reviews = new List<Review>();
            
        }

        public Guid GameId { get; private set; }
        public Guid UserId { get; set; }
        public string Name { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public decimal Price { get; private set; }
        public string Gender { get; private set; }
        public string Description { get; private set; }
        public string Developer { get; private set; }
        public string Publisher { get; private set; }
        public string Platform { get; private set; }
        public int AgeRating { get; private set; }
        public bool ItIsInPromotion { get; set; }
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
            Name = nome;
            Price = preco;
            Description = descricao;
            Publisher = publisher;
            Platform = plataforma;
        }
    }
}
