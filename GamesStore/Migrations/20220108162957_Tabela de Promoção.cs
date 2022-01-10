using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GamesStore.Migrations
{
    public partial class TabeladePromoção : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EstaEmPromocao",
                table: "Games",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Promocao",
                columns: table => new
                {
                    PromocaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameID = table.Column<int>(type: "int", nullable: false),
                    PrecoPromocional = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataInicialDaPromocao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataFinalDaPromocao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Promocao", x => x.PromocaoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Promocao");

            migrationBuilder.DropColumn(
                name: "EstaEmPromocao",
                table: "Games");
        }
    }
}
