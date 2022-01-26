namespace GamesStore.Entities
{
    public class Review
    {
        public Review()
        {

        }

        public Review(int userId, int gameId, string gamerTag, int stars, string title, string description)
        {
            UserId = userId;
            GameId = gameId;
            GamerTag = gamerTag;
            Stars = stars;
            Title = title;
            Description = description;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public int GameId { get; private set; }
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
