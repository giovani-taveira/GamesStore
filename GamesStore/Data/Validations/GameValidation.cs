using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GamesStore.Data
{
    public class GameValidation : IEntityTypeConfiguration<Games>
    {
        public void Configure(EntityTypeBuilder<Games> builder)
        {
            builder.Property(p => p.GameId).IsRequired();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.Gender).IsRequired();
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.ReleaseDate).IsRequired();
            builder.Property(p => p.Publisher).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Developer).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Platform).IsRequired();
            builder.Property(p => p.AgeRating).IsRequired();
        }
    }
}
