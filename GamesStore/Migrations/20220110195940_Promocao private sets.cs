using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class Promocaoprivatesets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameID",
                table: "Promocao",
                newName: "GameId");

            migrationBuilder.RenameColumn(
                name: "PromocaoID",
                table: "Promocao",
                newName: "PromocaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Promocao",
                newName: "GameID");

            migrationBuilder.RenameColumn(
                name: "PromocaoId",
                table: "Promocao",
                newName: "PromocaoID");
        }
    }
}
