using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class something3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "ShowImagesInInvoice",
                table: "Settings",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SalesOrderId",
                table: "Invoices",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_SalesOrderId",
                table: "Invoices",
                column: "SalesOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrderId",
                table: "Invoices",
                column: "SalesOrderId",
                principalTable: "SalesOrders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_SalesOrders_SalesOrderId",
                table: "Invoices");

            migrationBuilder.DropIndex(
                name: "IX_Invoices_SalesOrderId",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ShowImagesInInvoice",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "SalesOrderId",
                table: "Invoices");
        }
    }
}
