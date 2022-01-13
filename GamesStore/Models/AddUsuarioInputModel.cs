namespace GamesStore.Models
{
    public record class AddUsuarioInputModel(
        string nome,
        string nickName,
        string email,
        string senha,
        string dataDeNascimento
        )
    {
    }
}
