using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class RelacionamentoentreastabelasUsuarioeGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Games_UsuarioId",
                table: "Games",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Usuarios_UsuarioId",
                table: "Games",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Usuarios_UsuarioId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_UsuarioId",
                table: "Games");
        }
    }
}
