using GamesStore.Entities;

namespace GamesStore.Models
{
    public record class AddPromocaoInputModel(
        decimal PrecoPromocao,
        int Dias
        )
    {
        
    }
}
