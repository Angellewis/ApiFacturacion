using Microsoft.EntityFrameworkCore.Migrations;

namespace APiFac3.Migrations
{
    public partial class fact6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Articulos_articuloid",
                table: "Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Facturas_facturaid",
                table: "Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_clienteid",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Vendedores_vendedorid",
                table: "Facturas");

            migrationBuilder.AlterColumn<int>(
                name: "vendedorid",
                table: "Facturas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Facturas",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "facturaid",
                table: "Detalles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "articuloid",
                table: "Detalles",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Articulos_articuloid",
                table: "Detalles",
                column: "articuloid",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Facturas_facturaid",
                table: "Detalles",
                column: "facturaid",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_clienteid",
                table: "Facturas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Vendedores_vendedorid",
                table: "Facturas",
                column: "vendedorid",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Articulos_articuloid",
                table: "Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Detalles_Facturas_facturaid",
                table: "Detalles");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Clientes_clienteid",
                table: "Facturas");

            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Vendedores_vendedorid",
                table: "Facturas");

            migrationBuilder.AlterColumn<int>(
                name: "vendedorid",
                table: "Facturas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Facturas",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "facturaid",
                table: "Detalles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "articuloid",
                table: "Detalles",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Articulos_articuloid",
                table: "Detalles",
                column: "articuloid",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Detalles_Facturas_facturaid",
                table: "Detalles",
                column: "facturaid",
                principalTable: "Facturas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Clientes_clienteid",
                table: "Facturas",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Vendedores_vendedorid",
                table: "Facturas",
                column: "vendedorid",
                principalTable: "Vendedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
