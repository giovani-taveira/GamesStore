using System.ComponentModel.DataAnnotations;

namespace GamesStore.Entities
{
    public class Usuario
    {
        public Usuario(string nome, string nickName, string email, string senha)
        {
            Nome = nome;
            NickName = nickName;
            Email = email;
            Senha = senha;

            CreatedAt = DateTime.Now;
            Games = new List<Game>();
        }

        public int UsuarioId { get;  private set; }
        public string Nome { get; private set; }
        public string NickName { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataDeNascimento { get; set; }
        public DateTime CreatedAt { get; private set; }
        public List<Game> Games { get; private set; }

        public void Update(string nome, string nickName, string senha)
        {
            Nome = nome;
            NickName = nickName;
            Senha = senha;
        }

        public void AddGames(Game game)
        {
            Games.Add(game);
        }
    }
}
