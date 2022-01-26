using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class Renomeaçãodasentidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Bibliotecas_BibliotecaId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Carrinhos_CarrinhoId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_ListaDeDesejos_ListaDeDesejosId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Usuarios_UsuarioId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Bibliotecas");

            migrationBuilder.DropTable(
                name: "Carrinhos");

            migrationBuilder.DropTable(
                name: "ListaDeDesejos");

            migrationBuilder.DropTable(
                name: "Promocao");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Reviews",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Reviews",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "TagUsuario",
                table: "Reviews",
                newName: "GamerTag");

            migrationBuilder.RenameColumn(
                name: "Estrelas",
                table: "Reviews",
                newName: "Stars");

            migrationBuilder.RenameColumn(
                name: "Descrição",
                table: "Reviews",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "UsuarioId",
                table: "Games",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "Preco",
                table: "Games",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "Plataforma",
                table: "Games",
                newName: "Platform");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Games",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "ListaDeDesejosId",
                table: "Games",
                newName: "WishListId");

            migrationBuilder.RenameColumn(
                name: "Genero",
                table: "Games",
                newName: "Gender");

            migrationBuilder.RenameColumn(
                name: "EstaEmPromocao",
                table: "Games",
                newName: "ItIsInPromotion");

            migrationBuilder.RenameColumn(
                name: "Desenvolvedora",
                table: "Games",
                newName: "Developer");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Games",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "DataDeLancamento",
                table: "Games",
                newName: "ReleaseDate");

            migrationBuilder.RenameColumn(
                name: "ClassificacaoEtaria",
                table: "Games",
                newName: "AgeRating");

            migrationBuilder.RenameColumn(
                name: "CarrinhoId",
                table: "Games",
                newName: "LibraryId");

            migrationBuilder.RenameColumn(
                name: "BibliotecaId",
                table: "Games",
                newName: "CartId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UsuarioId",
                table: "Games",
                newName: "IX_Games_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_ListaDeDesejosId",
                table: "Games",
                newName: "IX_Games_WishListId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_CarrinhoId",
                table: "Games",
                newName: "IX_Games_LibraryId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_BibliotecaId",
                table: "Games",
                newName: "IX_Games_CartId");

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    SaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PromotionalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromotionStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PromotionEndDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.SaleId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GamerTag = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "BLibraries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BLibraries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BLibraries_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WishLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BLibraries_UserId",
                table: "BLibraries",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carts_UserId",
                table: "Carts",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WishLists_UserId",
                table: "WishLists",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_BLibraries_LibraryId",
                table: "Games",
                column: "LibraryId",
                principalTable: "BLibraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Carts_CartId",
                table: "Games",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_WishLists_WishListId",
                table: "Games",
                column: "WishListId",
                principalTable: "WishLists",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_BLibraries_LibraryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Carts_CartId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Users_UserId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_WishLists_WishListId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "BLibraries");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Reviews",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Reviews",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Stars",
                table: "Reviews",
                newName: "Estrelas");

            migrationBuilder.RenameColumn(
                name: "GamerTag",
                table: "Reviews",
                newName: "TagUsuario");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Reviews",
                newName: "Descrição");

            migrationBuilder.RenameColumn(
                name: "WishListId",
                table: "Games",
                newName: "ListaDeDesejosId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Games",
                newName: "UsuarioId");

            migrationBuilder.RenameColumn(
                name: "ReleaseDate",
                table: "Games",
                newName: "DataDeLancamento");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Games",
                newName: "Preco");

            migrationBuilder.RenameColumn(
                name: "Platform",
                table: "Games",
                newName: "Plataforma");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Games",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "LibraryId",
                table: "Games",
                newName: "CarrinhoId");

            migrationBuilder.RenameColumn(
                name: "ItIsInPromotion",
                table: "Games",
                newName: "EstaEmPromocao");

            migrationBuilder.RenameColumn(
                name: "Gender",
                table: "Games",
                newName: "Genero");

            migrationBuilder.RenameColumn(
                name: "Developer",
                table: "Games",
                newName: "Desenvolvedora");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Games",
                newName: "Descricao");

            migrationBuilder.RenameColumn(
                name: "CartId",
                table: "Games",
                newName: "BibliotecaId");

            migrationBuilder.RenameColumn(
                name: "AgeRating",
                table: "Games",
                newName: "ClassificacaoEtaria");

            migrationBuilder.RenameIndex(
                name: "IX_Games_WishListId",
                table: "Games",
                newName: "IX_Games_ListaDeDesejosId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_UserId",
                table: "Games",
                newName: "IX_Games_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_LibraryId",
                table: "Games",
                newName: "IX_Games_CarrinhoId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_CartId",
                table: "Games",
                newName: "IX_Games_BibliotecaId");

            migrationBuilder.CreateTable(
                name: "Promocao",
                columns: table => new
                {
                    PromocaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataFinalDaPromocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInicialDaPromocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GameId = table.Column<int>(type: "int", nullable: false),
                    PrecoPromocional = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocao", x => x.PromocaoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Senha = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Bibliotecas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bibliotecas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bibliotecas_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Carrinhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carrinhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carrinhos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListaDeDesejos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaDeDesejos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ListaDeDesejos_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bibliotecas_UsuarioId",
                table: "Bibliotecas",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Carrinhos_UsuarioId",
                table: "Carrinhos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListaDeDesejos_UsuarioId",
                table: "ListaDeDesejos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Bibliotecas_BibliotecaId",
                table: "Games",
                column: "BibliotecaId",
                principalTable: "Bibliotecas",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Carrinhos_CarrinhoId",
                table: "Games",
                column: "CarrinhoId",
                principalTable: "Carrinhos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ListaDeDesejos_ListaDeDesejosId",
                table: "Games",
                column: "ListaDeDesejosId",
                principalTable: "ListaDeDesejos",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Usuarios_UsuarioId",
                table: "Games",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
