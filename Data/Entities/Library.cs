namespace GamesStore.Entities
{
    public class Library
    {
        public Library()
        {
            Games = new List<Games>();
        }

        public Library(Guid userId)
        {
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public List<Games> Games { get; private set; }

        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
