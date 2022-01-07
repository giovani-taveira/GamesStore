using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.Data
{
    public class GameValidation : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.Property(p => p.GameId).IsRequired();
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Preco).IsRequired();
            builder.Property(p => p.Genero).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.DataDeLancamento).IsRequired();
            builder.Property(p => p.Publisher).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Desenvolvedora).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Plataforma).IsRequired();
            builder.Property(p => p.ClassificacaoEtaria).IsRequired();
        }
    }
}
