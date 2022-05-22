using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.Data.Validations
{
    public class UserValidation : IEntityTypeConfiguration<User>
    {

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.GamerTag).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(150);
            builder.Property(p => p.Password).IsRequired().HasMaxLength(50);
            builder.Property(p => p.DateOfBirth).IsRequired();
        }
    }
}
