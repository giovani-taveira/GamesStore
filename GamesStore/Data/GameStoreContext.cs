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
            #region Primary Keys
            modelBuilder.Entity<Games>()
                .HasKey(e => e.GameId);

            modelBuilder.Entity<Promocao>()
                .HasKey(e => e.PromocaoId);

            modelBuilder.Entity<Usuario>()
                .HasKey(e => e.UsuarioId);

            modelBuilder.Entity<Carrinho>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<ListaDeDesejos>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Biblioteca>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Review>()
                .HasKey(e => e.Id);

            #endregion


            #region Froreign Keys
            modelBuilder.Entity<Games>()
                .HasMany(c => c.Reviews)
                .WithOne()
                .HasForeignKey(c => c.GameId);

            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.Carrinho)
                .WithOne()
                .HasForeignKey<Carrinho>(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.ListaDeDesejos)
                .WithOne()
                .HasForeignKey<ListaDeDesejos>(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasOne(c => c.Biblioteca)
                .WithOne()
                .HasForeignKey<Biblioteca>(c => c.UsuarioId);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Games)
                .WithOne()
                .HasForeignKey(e => e.UsuarioId);
            #endregion

        }

        public DbSet<Games> Games { get; set; }
        public DbSet<Promocao> Promocao { get; set;}
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ListaDeDesejos> ListaDeDesejos { get; set; }
        public DbSet<Biblioteca> Bibliotecas { get; set; }

    }
}
