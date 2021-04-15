using Microsoft.EntityFrameworkCore.Migrations;

namespace APiFac3.Migrations
{
    public partial class LastOne : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Asiento",
                table: "Facturas",
                nullable: true,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Asiento",
                table: "Facturas");
        }
    }
}
