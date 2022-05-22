namespace GamesStore.Entities
{
    public class Review
    {
        public Review()
        {

        }

        public Review(Guid userId, Guid gameId, string gamerTag, int stars, string title, string description)
        {
            UserId = userId;
            GameId = gameId;
            GamerTag = gamerTag;
            Stars = stars;
            Title = title;
            Description = description;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public Guid GameId { get; private set; }
        public string GamerTag { get; private set; }
        public int Stars { get; private set; }
        public string Title { get; private set; }
        public string Description { get; set; }

        public void UpdateReview(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
