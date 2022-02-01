using GamesStore.Entities;

namespace GamesStore.Models
{
    public record class AddSaleInputModel(
        decimal promotionalPrice,
        int days
        )
    {

    }
}

