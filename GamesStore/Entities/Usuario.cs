using System.ComponentModel.DataAnnotations;

namespace GamesStore.Entities
{
    public class Usuario
    {
        protected Usuario()
        {
            Games = new List<Games>();
            CreatedAt = DateTime.Now;
        }

        public Usuario(string nome, string nickName, string email, string senha, string dataNascimento)
        {
            Nome = nome;
            NickName = nickName;
            Email = email;
            Senha = senha;

            DataDeNascimento = DateTime.ParseExact(dataNascimento, "dd/MM/yyy", null);                      
        }

        public int UsuarioId { get;  private set; }
        public string Nome { get; private set; }
        public string NickName { get; private set; }
        public string Email { get; private set; }
        public string Senha { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public List<Games> Games { get; private set; }
        public Carrinho Carrinho { get; private set; }
        public ListaDeDesejos ListaDeDesejos { get; private set; }
        public Biblioteca Biblioteca { get; private set; }

        public void Update(string nome, string nickName, string senha)
        {
            Nome = nome;
            NickName = nickName;
            Senha = senha;
        }

        public void AddGames(Games game)
        {
            Games.Add(game);
        }
    }
}
