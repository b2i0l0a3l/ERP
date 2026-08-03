using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SomethingNews : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "Customers",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_FristName",
                table: "Customers",
                newName: "IX_Customers_FirstName");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "CostPrice",
                table: "SalesOrderItems",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "CostPrice",
                table: "SalesOrderItems");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Customers",
                newName: "FristName");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_FirstName",
                table: "Customers",
                newName: "IX_Customers_FristName");
        }
    }
}
