using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddLineTotalComputed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_InvoiceItemLineTotal",
                table: "InvoiceItems");

            migrationBuilder.AlterColumn<decimal>(
                name: "LineTotal",
                table: "InvoiceItems",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                computedColumnSql: "CAST((UnitPrice * Quantity) * (1.0 + (TaxRate / 100.0)) AS DECIMAL(18,2))",
                stored: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldDefaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "LineTotal",
                table: "InvoiceItems",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2,
                oldComputedColumnSql: "CAST((UnitPrice * Quantity) * (1.0 + (TaxRate / 100.0)) AS DECIMAL(18,2))");

            migrationBuilder.AddCheckConstraint(
                name: "CK_InvoiceItemLineTotal",
                table: "InvoiceItems",
                sql: "[LineTotal] >= 0");
        }
    }
}
