namespace GamesStore.Models
{
    public record class UpdateGameInputModel(
        string name,
        decimal price,
        string description,
        string publisher,
        string platform
        )
    {
    }
}
