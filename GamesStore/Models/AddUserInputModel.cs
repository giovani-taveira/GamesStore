namespace GamesStore.Models
{
    public record class AddUserInputModel(
        string name,
        string gamerTag,
        string email,
        string password,
        string dayOfByrth
        )
    {
    }
}
