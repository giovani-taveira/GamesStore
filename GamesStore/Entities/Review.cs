namespace GamesStore.Entities
{
    public class Review
    {
        public Review()
        {

        }


        //public Review(int userId, int gameId, string tag, int estrelas, string titulo, string descricao)
        //{
        //    UsuarioId = userId;
        //    GameId = gameId;
        //    TagUsuario = tag;
        //    Estrelas = estrelas;
        //    Titulo = titulo;
        //    Descrição = descricao;
        //}

        public int Id { get; private set; }
        public int UsuarioId { get; set; }
        public int GameId { get; set; }
        public string TagUsuario { get;  set; }
        public int Estrelas { get; private set; }
        public string Titulo { get; private set; }
        public string Descrição { get; set; }

        public void UpdateReview(string titulo, string descricao)
        {
            Titulo = titulo;
            Descrição = descricao;
        }

    }
}
