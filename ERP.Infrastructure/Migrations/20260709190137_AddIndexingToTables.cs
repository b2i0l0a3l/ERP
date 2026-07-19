using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexingToTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_SaleOrderItemSellingPrice",
                table: "SalesOrderItems");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments");

            migrationBuilder.CreateIndex(
                name: "IX_Warehouses_Name",
                table: "Warehouses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_CompanyName",
                table: "Settings",
                column: "CompanyName");

            migrationBuilder.CreateIndex(
                name: "IX_Settings_Tax",
                table: "Settings",
                column: "Tax");

            migrationBuilder.CreateIndex(
                name: "IX_SalesOrders_CreatedAt",
                table: "SalesOrders",
                column: "CreatedAt");

            migrationBuilder.AddCheckConstraint(
                name: "CK_SaleOrderItemSellingPrice",
                table: "SalesOrderItems",
                sql: "[SellingPrice] >= 0 ");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrders_CreatedAt",
                table: "PurchaseOrders",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseOrderItems_CreatedAt",
                table: "PurchaseOrderItems",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Barcode",
                table: "Products",
                column: "Barcode");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CreatedAt",
                table: "Products",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Payments_CreatedAt",
                table: "Payments",
                column: "CreatedAt");

            migrationBuilder.AddCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments",
                sql: "[PaymentMethod] in (1,2,3)");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_FristName",
                table: "Customers",
                column: "FristName");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerAddresses_Name",
                table: "CustomerAddresses",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Warehouses_Name",
                table: "Warehouses");

            migrationBuilder.DropIndex(
                name: "IX_Settings_CompanyName",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_Settings_Tax",
                table: "Settings");

            migrationBuilder.DropIndex(
                name: "IX_SalesOrders_CreatedAt",
                table: "SalesOrders");

            migrationBuilder.DropCheckConstraint(
                name: "CK_SaleOrderItemSellingPrice",
                table: "SalesOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrders_CreatedAt",
                table: "PurchaseOrders");

            migrationBuilder.DropIndex(
                name: "IX_PurchaseOrderItems_CreatedAt",
                table: "PurchaseOrderItems");

            migrationBuilder.DropIndex(
                name: "IX_Products_Barcode",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CreatedAt",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Name",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Payments_CreatedAt",
                table: "Payments");

            migrationBuilder.DropCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Customers_FristName",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_CustomerAddresses_Name",
                table: "CustomerAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Name",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                table: "Brands");

            migrationBuilder.AddCheckConstraint(
                name: "CK_SaleOrderItemSellingPrice",
                table: "SalesOrderItems",
                sql: "[SellingPrice] >=0 0 ");

            migrationBuilder.AddCheckConstraint(
                name: "CK_PaymentMethod",
                table: "Payments",
                sql: "[PaymentMethod] in 1,2,3");
        }
    }
}
