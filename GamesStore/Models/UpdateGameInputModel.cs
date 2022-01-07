namespace GamesStore.Models
{
    public record class UpdateGameInputModel(
        string nome,
        decimal preco,
        string descricao,
        string publisher,
        string plataforma
        )
    {
    }
}
