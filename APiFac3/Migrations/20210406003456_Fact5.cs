using Microsoft.EntityFrameworkCore.Migrations;

namespace APiFac3.Migrations
{
    public partial class Fact5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cant_articulo",
                table: "Detalles",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cant_articulo",
                table: "Detalles");
        }
    }
}
