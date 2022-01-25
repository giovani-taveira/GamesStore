namespace GamesStore.Entities
{
    public class ListaDeDesejos
    {
        public ListaDeDesejos()
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
