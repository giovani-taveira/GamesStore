namespace GamesStore.Models
{
    public record class AddReviewInputModel(
        string title,
        int stars,
        string description
        )
    {
    }
}
