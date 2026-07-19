using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.shared
{
    public enum ErrorType { NotFound,Conflict,Forbidden, Validation, Unauthorized,General }

    public record Error(string Id, ErrorType Type, string Description);

    public static class Errors
    {
        public static Error AccountNotFound { get; } = new("AccountNotFound", ErrorType.NotFound, "Account not found.");
        public static Error ProductNotFound { get; } = new("ProductNotFound", ErrorType.NotFound, "Product not found.");
        public static Error InsufficientFunds { get; } = new("InsufficientFunds", ErrorType.Validation, "Insufficient balance.");

        public static Error BrandNotFound { get; } = new("BrandNotFound", ErrorType.NotFound, "Brand not found.");
        public static Error CategoryNotFound { get; } = new("CategoryNotFound", ErrorType.NotFound, "Category not found.");
        public static Error CustomerNotFound { get; } = new("CustomerNotFound", ErrorType.NotFound, "Customer not found.");
        public static Error CustomerAddressNotFound { get; } = new("CustomerAddressNotFound", ErrorType.NotFound, "Customer address not found.");
        public static Error CustomerPhoneNumberNotFound { get; } = new("CustomerPhoneNumberNotFound", ErrorType.NotFound, "Customer phone number not found.");
        public static Error InventoryNotFound { get; } = new("InventoryNotFound", ErrorType.NotFound, "Inventory not found.");
        public static Error PaymentNotFound { get; } = new("PaymentNotFound", ErrorType.NotFound, "Payment not found.");
        public static Error ProductImageNotFound { get; } = new("ProductImageNotFound", ErrorType.NotFound, "Product image not found.");
        public static Error PurchaseOrderNotFound { get; } = new("PurchaseOrderNotFound", ErrorType.NotFound, "Purchase order not found.");
        public static Error PurchaseOrderItemNotFound { get; } = new("PurchaseOrderItemNotFound", ErrorType.NotFound, "Purchase order item not found.");
        public static Error SalesOrderNotFound { get; } = new("SalesOrderNotFound", ErrorType.NotFound, "Sales order not found.");
        public static Error SalesOrderItemNotFound { get; } = new("SalesOrderItemNotFound", ErrorType.NotFound, "Sales order item not found.");
        public static Error SettingNotFound { get; } = new("SettingNotFound", ErrorType.NotFound, "Setting not found.");
        public static Error SupplierNotFound { get; } = new("SupplierNotFound", ErrorType.NotFound, "Supplier not found.");
        public static Error UserNotFound { get; } = new("UserNotFound", ErrorType.NotFound, "User not found.");
        public static Error WarehouseNotFound { get; } = new("WarehouseNotFound", ErrorType.NotFound, "Warehouse not found.");
    }
}