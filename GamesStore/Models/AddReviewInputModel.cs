namespace GamesStore.Models
{
    public record class AddReviewInputModel(
        string titulo,
        int estrelas,
        string descricao
        )
    {
    }
}
