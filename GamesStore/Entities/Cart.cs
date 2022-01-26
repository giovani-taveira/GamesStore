namespace GamesStore.Entities
{
    public class Cart
    {
        public Cart()
        {
            Games = new List<Games>();
        }

        public Cart(int userId)
        {
            UserId = userId;
        }

        public int Id { get; private set; }
        public int UserId { get; private set; }
        public List<Games> Games  { get; private set; }


        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
