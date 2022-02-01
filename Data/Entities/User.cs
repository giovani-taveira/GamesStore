using System.ComponentModel.DataAnnotations;

namespace GamesStore.Entities
{
    public class User
    {
        protected User()
        {
            Games = new List<Games>();
            CreatedAt = DateTime.Now;
        }

        public int UserId { get;  private set; }
        public string Name { get; private set; }
        public string GamerTag { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public DateTime DateOfBirth { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Games> Games { get; private set; }
        public Cart Cart { get; private set; }
        public WishList WishList { get; private set; }
        public Library Library { get; private set; }

        public void Update(string nome, string nickName, string senha)
        {
            Name = nome;
            GamerTag = nickName;
            Password = senha;
        }

        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
