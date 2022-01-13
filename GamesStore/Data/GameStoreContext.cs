using GamesStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GamesStore.Data
{
    public class GameStoreContext : DbContext
    {

        public GameStoreContext(DbContextOptions<GameStoreContext> option)
            : base(option) 
        { 

        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Game>()
                .HasKey(e => e.GameId);


            modelBuilder.Entity<Promocao>()
                .HasKey(e => e.PromocaoId);

            modelBuilder.Entity<Usuario>()
                .HasKey(e => e.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Games)
                .WithOne()
                .HasForeignKey(e => e.UsuarioId);

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Promocao> Promocao { get; set;}
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
