using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class WishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ListaDeDesejosId",
                table: "Games",
                type: "int",
                nullable: true);

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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_ListaDeDesejosId",
                table: "Games",
                column: "ListaDeDesejosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_ListaDeDesejos_ListaDeDesejosId",
                table: "Games",
                column: "ListaDeDesejosId",
                principalTable: "ListaDeDesejos",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_ListaDeDesejos_ListaDeDesejosId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "ListaDeDesejos");

            migrationBuilder.DropIndex(
                name: "IX_Games_ListaDeDesejosId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ListaDeDesejosId",
                table: "Games");
        }
    }
}
