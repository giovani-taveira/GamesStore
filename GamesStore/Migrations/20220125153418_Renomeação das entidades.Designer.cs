﻿// <auto-generated />
using System;
using GamesStore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GamesStore.Migrations
{
    [DbContext(typeof(GameStoreContext))]
    [Migration("20220125153418_Renomeação das entidades")]
    partial class Renomeaçãodasentidades
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("GamesStore.Entities.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("GamesStore.Entities.Games", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GameId"), 1L, 1);

                    b.Property<int>("AgeRating")
                        .HasColumnType("int");

                    b.Property<int?>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Developer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("ItIsInPromotion")
                        .HasColumnType("bit");

                    b.Property<int?>("LibraryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Platform")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Publisher")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WishListId")
                        .HasColumnType("int");

                    b.HasKey("GameId");

                    b.HasIndex("CartId");

                    b.HasIndex("LibraryId");

                    b.HasIndex("UserId");

                    b.HasIndex("WishListId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("GamesStore.Entities.Library", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("BLibraries");
                });

            modelBuilder.Entity("GamesStore.Entities.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("GamerTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Stars")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("GamesStore.Entities.Sale", b =>
                {
                    b.Property<int>("SaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SaleId"), 1L, 1);

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PromotionEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("PromotionStartDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("PromotionalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SaleId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("GamesStore.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GamerTag")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("GamesStore.Entities.WishList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("WishLists");
                });

            modelBuilder.Entity("GamesStore.Entities.Cart", b =>
                {
                    b.HasOne("GamesStore.Entities.User", null)
                        .WithOne("Cart")
                        .HasForeignKey("GamesStore.Entities.Cart", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Entities.Games", b =>
                {
                    b.HasOne("GamesStore.Entities.Cart", null)
                        .WithMany("Games")
                        .HasForeignKey("CartId");

                    b.HasOne("GamesStore.Entities.Library", null)
                        .WithMany("Games")
                        .HasForeignKey("LibraryId");

                    b.HasOne("GamesStore.Entities.User", null)
                        .WithMany("Games")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GamesStore.Entities.WishList", null)
                        .WithMany("Games")
                        .HasForeignKey("WishListId");
                });

            modelBuilder.Entity("GamesStore.Entities.Library", b =>
                {
                    b.HasOne("GamesStore.Entities.User", null)
                        .WithOne("Library")
                        .HasForeignKey("GamesStore.Entities.Library", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Entities.Review", b =>
                {
                    b.HasOne("GamesStore.Entities.Games", null)
                        .WithMany("Reviews")
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Entities.WishList", b =>
                {
                    b.HasOne("GamesStore.Entities.User", null)
                        .WithOne("WishList")
                        .HasForeignKey("GamesStore.Entities.WishList", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Entities.Cart", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesStore.Entities.Games", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("GamesStore.Entities.Library", b =>
                {
                    b.Navigation("Games");
                });

            modelBuilder.Entity("GamesStore.Entities.User", b =>
                {
                    b.Navigation("Cart")
                        .IsRequired();

                    b.Navigation("Games");

                    b.Navigation("Library")
                        .IsRequired();

                    b.Navigation("WishList")
                        .IsRequired();
                });

            modelBuilder.Entity("GamesStore.Entities.WishList", b =>
                {
                    b.Navigation("Games");
                });
#pragma warning restore 612, 618
        }
    }
}
