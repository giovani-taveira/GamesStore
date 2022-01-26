using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.Data.Validations
{
    public class SaleValidations : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.Property(x => x.GameId).IsRequired();
            builder.Property(x => x.PromotionEndDate).IsRequired();
            builder.Property(x => x.PromotionalPrice).IsRequired();

        }

    }
}
