using Microsoft.EntityFrameworkCore.Migrations;

namespace APiFac3.Migrations
{
    public partial class TheLast : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Asiento",
                table: "Facturas",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Asiento",
                table: "Facturas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
