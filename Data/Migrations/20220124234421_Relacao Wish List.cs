using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class RelacaoWishList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ListaDeDesejos_UsuarioId",
                table: "ListaDeDesejos",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListaDeDesejos_Usuarios_UsuarioId",
                table: "ListaDeDesejos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListaDeDesejos_Usuarios_UsuarioId",
                table: "ListaDeDesejos");

            migrationBuilder.DropIndex(
                name: "IX_ListaDeDesejos_UsuarioId",
                table: "ListaDeDesejos");
        }
    }
}
