namespace ERP.Core.shared
{
    public static class AppPolicies
    {
        public const string AdminOnly = "AdminOnly";
        public const string StaffOrAdmin = "StaffOrAdmin";
        public const string UserOrAdmin = "UserOrAdmin";
        public const string AllRoles = "AllRoles";
    }
}
