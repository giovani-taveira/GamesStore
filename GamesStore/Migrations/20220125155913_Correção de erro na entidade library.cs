using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class Correçãodeerronaentidadelibrary : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLibraries_Users_UserId",
                table: "BLibraries");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_BLibraries_LibraryId",
                table: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BLibraries",
                table: "BLibraries");

            migrationBuilder.RenameTable(
                name: "BLibraries",
                newName: "Libraries");

            migrationBuilder.RenameIndex(
                name: "IX_BLibraries_UserId",
                table: "Libraries",
                newName: "IX_Libraries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Libraries_LibraryId",
                table: "Games",
                column: "LibraryId",
                principalTable: "Libraries",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Libraries_Users_UserId",
                table: "Libraries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Libraries_LibraryId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Libraries_Users_UserId",
                table: "Libraries");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Libraries",
                table: "Libraries");

            migrationBuilder.RenameTable(
                name: "Libraries",
                newName: "BLibraries");

            migrationBuilder.RenameIndex(
                name: "IX_Libraries_UserId",
                table: "BLibraries",
                newName: "IX_BLibraries_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BLibraries",
                table: "BLibraries",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BLibraries_Users_UserId",
                table: "BLibraries",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_BLibraries_LibraryId",
                table: "Games",
                column: "LibraryId",
                principalTable: "BLibraries",
                principalColumn: "Id");
        }
    }
}
