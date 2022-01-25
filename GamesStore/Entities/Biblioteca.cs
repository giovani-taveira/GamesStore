namespace GamesStore.Entities
{
    public class Biblioteca
    {
        public Biblioteca()
        {
            Games = new List<Games>();
        }

        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public List<Games> Games { get; set; }

        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
