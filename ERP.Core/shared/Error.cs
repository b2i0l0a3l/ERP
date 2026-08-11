using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.shared
{
    public enum ErrorType { NotFound, Conflict, Forbidden, Validation, Unauthorized, General }

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
        public static Error InvoiceNotFound { get; } = new("InvoiceNotFound", ErrorType.NotFound, "Invoice not found.");
        public static Error InvoiceItemNotFound { get; } = new("InvoiceItemNotFound", ErrorType.NotFound, "Invoice item not found.");
        public static Error NotificationNotFound { get; } = new("NotificationNotFound", ErrorType.NotFound, "Notification not found.");
        public static Error ReturnNotFound { get; } = new("ReturnNotFound", ErrorType.NotFound, "Return not found.");

        // Auth Errors
        public static Error InvalidCredentials { get; } = new("InvalidCredentials", ErrorType.Unauthorized, "Invalid email or password.");
        public static Error UserNotAuthorized { get; } = new("UserNotAuthorized", ErrorType.Unauthorized, "User Not Authorized.");
        public static Error RefreshtokenRevoked { get; } = new("RefreshtokenRevoked", ErrorType.Unauthorized, "Refresh token is revoked.");
        public static Error RefreshTokenExpired { get; } = new("RefreshTokenExpired", ErrorType.Unauthorized, "Refresh token is Expired.");
        public static Error AccountDeactivated { get; } = new("AccountDeactivated", ErrorType.Forbidden, "This account has been deactivated.");
        public static Error EmailAlreadyExists { get; } = new("EmailAlreadyExists", ErrorType.Conflict, "A user with this email already exists.");
        public static Error RegistrationFailed { get; } = new("RegistrationFailed", ErrorType.Validation, "User registration failed.");
        public static Error InvalidToken { get; } = new("InvalidToken", ErrorType.Unauthorized, "The provided token is invalid.");
        public static Error TokenExpired { get; } = new("TokenExpired", ErrorType.Unauthorized, "The refresh token has expired.");
        public static Error RoleNotFound { get; } = new("RoleNotFound", ErrorType.NotFound, "The specified role does not exist.");
        public static Error UserAlreadyInRole { get; } = new("UserAlreadyInRole", ErrorType.Conflict, "The user is already assigned to this role.");
        public static Error UserNotInRole { get; } = new("UserNotInRole", ErrorType.NotFound, "The user is not assigned to this role.");
    }
}