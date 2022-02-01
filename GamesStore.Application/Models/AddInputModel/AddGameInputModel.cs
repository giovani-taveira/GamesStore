namespace GamesStore.Models
{
    public record class AddGameInputModel(
        string name,
        decimal price,
        string releaseDate,
        string gender,
        string description,
        string developer,
        string publisher,
        string platform,
        int ageRating
        )
    {

    } 
}
