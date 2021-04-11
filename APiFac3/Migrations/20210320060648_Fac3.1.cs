using Microsoft.EntityFrameworkCore.Migrations;

namespace APiFac3.Migrations
{
    public partial class Fac31 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Detalles_articuloid",
                table: "Articulos");

            migrationBuilder.DropIndex(
                name: "IX_Articulos_articuloid",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "articuloid",
                table: "Articulos");

            migrationBuilder.AddColumn<int>(
                name: "articuloid",
                table: "Detalles",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_articuloid",
                table: "Detalles",
                column: "articuloid");

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Articulos_articuloid",
                table: "Detalles",
                column: "articuloid",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Articulos_articuloid",
                table: "Detalles");

            migrationBuilder.DropIndex(
                name: "IX_Detalles_articuloid",
                table: "Detalles");

            migrationBuilder.DropColumn(
                name: "articuloid",
                table: "Detalles");

            migrationBuilder.AddColumn<int>(
                name: "articuloid",
                table: "Articulos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_articuloid",
                table: "Articulos",
                column: "articuloid");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Detalles_articuloid",
                table: "Articulos",
                column: "articuloid",
                principalTable: "Detalles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
