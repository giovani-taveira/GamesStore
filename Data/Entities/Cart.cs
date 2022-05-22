namespace GamesStore.Entities
{
    public class Cart
    {
        public Cart()
        {
            Games = new List<Games>();
        }

        public Cart(Guid userId)
        {
            UserId = userId;
        }

        public Guid Id { get; private set; }
        public Guid UserId { get; private set; }
        public List<Games> Games  { get; private set; }


        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
