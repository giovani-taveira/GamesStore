namespace GamesStore.Models
{
    public record class AddGameInputModel(
        string nome,
        decimal preco,
        DateTime dataDeLancamento,
        string genero,
        string descricao,
        string Desenvolvedora,
        string Publisher,
        string Plataforma,
        int classificacaoEtaria
        )
    {

    }
}
