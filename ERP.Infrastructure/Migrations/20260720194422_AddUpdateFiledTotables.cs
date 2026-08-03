using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUpdateFiledTotables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Warehouses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Suppliers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "StockAdjustmentLogs",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Settings",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "SalesOrders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "SalesOrderItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Returns",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ReturnItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "PurchaseOrders",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "PurchaseOrderItems",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "ProductImages",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Payments",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Inventories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "CustomerPhoneNumbers",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "CustomerAddresses",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "Brands",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETUTCDATE()");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Warehouses");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Settings");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "SalesOrders");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "SalesOrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Returns");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ReturnItems");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "PurchaseOrders");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "PurchaseOrderItems");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "ProductImages");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "CustomerAddresses");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "Brands");
        }
    }
}
