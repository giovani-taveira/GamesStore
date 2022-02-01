using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class RelacaotabelasGamescomReview : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Games_GamesGameId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_GamesGameId",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "GamesGameId",
                table: "Reviews");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Games_GameId",
                table: "Reviews",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "GameId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Games_GameId",
                table: "Reviews");

            migrationBuilder.DropIndex(
                name: "IX_Reviews_GameId",
                table: "Reviews");

            migrationBuilder.AddColumn<int>(
                name: "GamesGameId",
                table: "Reviews",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_GamesGameId",
                table: "Reviews",
                column: "GamesGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Games_GamesGameId",
                table: "Reviews",
                column: "GamesGameId",
                principalTable: "Games",
                principalColumn: "GameId");
        }
    }
}
