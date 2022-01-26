namespace GamesStore.Entities
{
    public class Library
    {
        public Library()
        {
            Games = new List<Games>();
        }

        public Library(int userId)
        {
            UserId = userId;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public List<Games> Games { get; private set; }

        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
