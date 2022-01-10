using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.Data.Validations
{
    public class PromocaoValidations : IEntityTypeConfiguration<Promocao>
    {
        public void Configure(EntityTypeBuilder<Promocao> builder)
        {
            builder.Property(x => x.GameId).IsRequired();
            builder.Property(x => x.DataFinalDaPromocao).IsRequired();
            builder.Property(x => x.PrecoPromocional).IsRequired();

        }

    }
}
