using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_Users_DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Users_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_Users_CreatedByUserId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_Users_DeletedByUserId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_Users_CreatedByUserId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_Users_DeletedByUserId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_CreatedByUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_DeletedByUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Users_CreatedByUserId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Users_DeletedByUserId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Users_CreatedByUserId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_Users_DeletedByUserId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_CreatedByUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Users_DeletedByUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_CreatedByUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_Users_DeletedByUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_Users_DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItems_Users_CreatedByUserId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItems_Users_DeletedByUserId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Users_CreatedByUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_Users_DeletedByUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnItems_Users_CreatedByUserId",
                table: "ReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnItems_Users_DeletedByUserId",
                table: "ReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_Users_CreatedByUserId",
                table: "Returns");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_Users_DeletedByUserId",
                table: "Returns");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_Users_CreatedByUserId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_Users_DeletedByUserId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Users_CreatedByUserId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_Users_DeletedByUserId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_CreatedByUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_Users_DeletedByUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustmentLogs_Users_AdjustedByUserId",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustmentLogs_Users_CreatedByUserId",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustmentLogs_Users_DeletedByUserId",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Users_CreatedByUserId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Users_DeletedByUserId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Users_CreatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_Users_DeletedByUserId",
                table: "Warehouses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Warehouses",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Suppliers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "StockAdjustmentLogs",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Settings",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "SalesOrders",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "SalesOrderItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Returns",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "ReturnItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "PurchaseOrders",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "PurchaseOrderItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Products",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "ProductImages",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Payments",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Invoices",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "InvoiceItems",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Inventories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Customers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "CustomerPhoneNumbers",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "CustomerAddresses",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Categories",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                table: "Brands",
                newName: "UpdatedAt");

            migrationBuilder.RenameColumn(
                name: "FristName",
                table: "AspNetUsers",
                newName: "FirstName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()",
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AccessFailedCount",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "LockoutEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "LockoutEnd",
                table: "AspNetUsers",
                type: "datetimeoffset",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedEmail",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NormalizedUserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SecurityStamp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "TwoFactorEnabled",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", maxLength: 450, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_AspNetUsers_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_AspNetUsers_DeletedByUserId",
                table: "Brands",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_AspNetUsers_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_AspNetUsers_CreatedByUserId",
                table: "CustomerAddresses",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_AspNetUsers_DeletedByUserId",
                table: "CustomerAddresses",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_AspNetUsers_CreatedByUserId",
                table: "CustomerPhoneNumbers",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_AspNetUsers_DeletedByUserId",
                table: "CustomerPhoneNumbers",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_CreatedByUserId",
                table: "Customers",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_AspNetUsers_DeletedByUserId",
                table: "Customers",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_AspNetUsers_CreatedByUserId",
                table: "Inventories",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_AspNetUsers_DeletedByUserId",
                table: "Inventories",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_CreatedByUserId",
                table: "InvoiceItems",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_DeletedByUserId",
                table: "InvoiceItems",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_CreatedByUserId",
                table: "Invoices",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_AspNetUsers_DeletedByUserId",
                table: "Invoices",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_CreatedByUserId",
                table: "Payments",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_AspNetUsers_DeletedByUserId",
                table: "Payments",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_AspNetUsers_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_AspNetUsers_DeletedByUserId",
                table: "ProductImages",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItems_AspNetUsers_CreatedByUserId",
                table: "PurchaseOrderItems",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItems_AspNetUsers_DeletedByUserId",
                table: "PurchaseOrderItems",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_CreatedByUserId",
                table: "PurchaseOrders",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_DeletedByUserId",
                table: "PurchaseOrders",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnItems_AspNetUsers_CreatedByUserId",
                table: "ReturnItems",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnItems_AspNetUsers_DeletedByUserId",
                table: "ReturnItems",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_AspNetUsers_CreatedByUserId",
                table: "Returns",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_AspNetUsers_DeletedByUserId",
                table: "Returns",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_AspNetUsers_CreatedByUserId",
                table: "SalesOrderItems",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_AspNetUsers_DeletedByUserId",
                table: "SalesOrderItems",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_AspNetUsers_CreatedByUserId",
                table: "SalesOrders",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_AspNetUsers_DeletedByUserId",
                table: "SalesOrders",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AspNetUsers_CreatedByUserId",
                table: "Settings",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_AspNetUsers_DeletedByUserId",
                table: "Settings",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustmentLogs_AspNetUsers_AdjustedByUserId",
                table: "StockAdjustmentLogs",
                column: "AdjustedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustmentLogs_AspNetUsers_CreatedByUserId",
                table: "StockAdjustmentLogs",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustmentLogs_AspNetUsers_DeletedByUserId",
                table: "StockAdjustmentLogs",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatedByUserId",
                table: "Suppliers",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_AspNetUsers_DeletedByUserId",
                table: "Suppliers",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_CreatedByUserId",
                table: "Warehouses",
                column: "CreatedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_AspNetUsers_DeletedByUserId",
                table: "Warehouses",
                column: "DeletedByUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Brands_AspNetUsers_CreatedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Brands_AspNetUsers_DeletedByUserId",
                table: "Brands");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_CreatedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_AspNetUsers_DeletedByUserId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_AspNetUsers_CreatedByUserId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerAddresses_AspNetUsers_DeletedByUserId",
                table: "CustomerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_AspNetUsers_CreatedByUserId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_CustomerPhoneNumbers_AspNetUsers_DeletedByUserId",
                table: "CustomerPhoneNumbers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_CreatedByUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_AspNetUsers_DeletedByUserId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_AspNetUsers_CreatedByUserId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_AspNetUsers_DeletedByUserId",
                table: "Inventories");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_CreatedByUserId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceItems_AspNetUsers_DeletedByUserId",
                table: "InvoiceItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_CreatedByUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_AspNetUsers_DeletedByUserId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_CreatedByUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_Payments_AspNetUsers_DeletedByUserId",
                table: "Payments");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_AspNetUsers_CreatedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductImages_AspNetUsers_DeletedByUserId",
                table: "ProductImages");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_CreatedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_DeletedByUserId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItems_AspNetUsers_CreatedByUserId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItems_AspNetUsers_DeletedByUserId",
                table: "PurchaseOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_CreatedByUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrders_AspNetUsers_DeletedByUserId",
                table: "PurchaseOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnItems_AspNetUsers_CreatedByUserId",
                table: "ReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_ReturnItems_AspNetUsers_DeletedByUserId",
                table: "ReturnItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_AspNetUsers_CreatedByUserId",
                table: "Returns");

            migrationBuilder.DropForeignKey(
                name: "FK_Returns_AspNetUsers_DeletedByUserId",
                table: "Returns");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_AspNetUsers_CreatedByUserId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrderItems_AspNetUsers_DeletedByUserId",
                table: "SalesOrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_AspNetUsers_CreatedByUserId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SalesOrders_AspNetUsers_DeletedByUserId",
                table: "SalesOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AspNetUsers_CreatedByUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_Settings_AspNetUsers_DeletedByUserId",
                table: "Settings");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustmentLogs_AspNetUsers_AdjustedByUserId",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustmentLogs_AspNetUsers_CreatedByUserId",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_StockAdjustmentLogs_AspNetUsers_DeletedByUserId",
                table: "StockAdjustmentLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_CreatedByUserId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_AspNetUsers_DeletedByUserId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_CreatedByUserId",
                table: "Warehouses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warehouses_AspNetUsers_DeletedByUserId",
                table: "Warehouses");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "EmailIndex",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "AccessFailedCount",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "EmailConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LockoutEnd",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedEmail",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "NormalizedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PhoneNumberConfirmed",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SecurityStamp",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TwoFactorEnabled",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Warehouses",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Suppliers",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "StockAdjustmentLogs",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Settings",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "SalesOrders",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "SalesOrderItems",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Returns",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ReturnItems",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PurchaseOrders",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "PurchaseOrderItems",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Products",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "ProductImages",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Payments",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Invoices",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "InvoiceItems",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Inventories",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Customers",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "CustomerPhoneNumbers",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "CustomerAddresses",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Categories",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "UpdatedAt",
                table: "Brands",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Users",
                newName: "FristName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "IssueDate",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValueSql: "GETDATE()");

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PasswordHash",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_CreatedByUserId",
                table: "Brands",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Brands_Users_DeletedByUserId",
                table: "Brands",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_CreatedByUserId",
                table: "Categories",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Users_DeletedByUserId",
                table: "Categories",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_Users_CreatedByUserId",
                table: "CustomerAddresses",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerAddresses_Users_DeletedByUserId",
                table: "CustomerAddresses",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_Users_CreatedByUserId",
                table: "CustomerPhoneNumbers",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CustomerPhoneNumbers_Users_DeletedByUserId",
                table: "CustomerPhoneNumbers",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_CreatedByUserId",
                table: "Customers",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_DeletedByUserId",
                table: "Customers",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Users_CreatedByUserId",
                table: "Inventories",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Users_DeletedByUserId",
                table: "Inventories",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Users_CreatedByUserId",
                table: "InvoiceItems",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceItems_Users_DeletedByUserId",
                table: "InvoiceItems",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_CreatedByUserId",
                table: "Invoices",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Users_DeletedByUserId",
                table: "Invoices",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_CreatedByUserId",
                table: "Payments",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_Users_DeletedByUserId",
                table: "Payments",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_CreatedByUserId",
                table: "ProductImages",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductImages_Users_DeletedByUserId",
                table: "ProductImages",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_CreatedByUserId",
                table: "Products",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_DeletedByUserId",
                table: "Products",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItems_Users_CreatedByUserId",
                table: "PurchaseOrderItems",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItems_Users_DeletedByUserId",
                table: "PurchaseOrderItems",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Users_CreatedByUserId",
                table: "PurchaseOrders",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrders_Users_DeletedByUserId",
                table: "PurchaseOrders",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnItems_Users_CreatedByUserId",
                table: "ReturnItems",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ReturnItems_Users_DeletedByUserId",
                table: "ReturnItems",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_Users_CreatedByUserId",
                table: "Returns",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Returns_Users_DeletedByUserId",
                table: "Returns",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_Users_CreatedByUserId",
                table: "SalesOrderItems",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrderItems_Users_DeletedByUserId",
                table: "SalesOrderItems",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Users_CreatedByUserId",
                table: "SalesOrders",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SalesOrders_Users_DeletedByUserId",
                table: "SalesOrders",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_CreatedByUserId",
                table: "Settings",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Settings_Users_DeletedByUserId",
                table: "Settings",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustmentLogs_Users_AdjustedByUserId",
                table: "StockAdjustmentLogs",
                column: "AdjustedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustmentLogs_Users_CreatedByUserId",
                table: "StockAdjustmentLogs",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StockAdjustmentLogs_Users_DeletedByUserId",
                table: "StockAdjustmentLogs",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Users_CreatedByUserId",
                table: "Suppliers",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Users_DeletedByUserId",
                table: "Suppliers",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Users_CreatedByUserId",
                table: "Warehouses",
                column: "CreatedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Warehouses_Users_DeletedByUserId",
                table: "Warehouses",
                column: "DeletedByUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
