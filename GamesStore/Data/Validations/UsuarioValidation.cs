using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.Data.Validations
{
    public class UsuarioValidation : IEntityTypeConfiguration<Usuario>
    {

        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.Property(p => p.Nome).IsRequired().HasMaxLength(100);
            builder.Property(p => p.NickName).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Senha).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DataDeNascimento).IsRequired();
        }
    }
}
