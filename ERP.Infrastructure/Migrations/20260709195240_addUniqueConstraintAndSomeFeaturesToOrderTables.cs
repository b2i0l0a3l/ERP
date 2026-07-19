using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addUniqueConstraintAndSomeFeaturesToOrderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Products_Barcode",
                table: "Products");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "SalesOrders",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AddCheckConstraint(
                name: "CK_SaleOrderStatus",
                table: "SalesOrders",
                sql: "[Status] in (1,2,3,4,5)");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_OrderStatus",
                table: "PurchaseOrders",
                column: "OrderStatus");

            migrationBuilder.AddCheckConstraint(
                name: "CK_PurschaseOrderStatus",
                table: "PurchaseOrders",
                sql: "[OrderStatus] in (1,2,3,4,5)");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_SKU",
                table: "Products",
                column: "SKU",
                unique: true);

            migrationBuilder.AddCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments",
                sql: "[PaymentMethod] in (0,1,2)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_SaleOrderStatus",
                table: "SalesOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_OrderStatus",
                table: "PurchaseOrders");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PurschaseOrderStatus",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_Products_Barcode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SKU",
                table: "Products");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "SalesOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "OrderStatus",
                table: "PurchaseOrders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 1);

            migrationBuilder.AlterColumn<int>(
                name: "PaymentMethod",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode");

            migrationBuilder.AddCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments",
                sql: "[PaymentMethod] in (1,2,3)");
        }
    }
}
