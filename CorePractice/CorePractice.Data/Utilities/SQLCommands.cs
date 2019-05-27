namespace CorePractice.Data.Utilities
{
    public static class SQLCommands
    {
        public const string Customers_Read = "EXEC [dbo].[Customers_Read]";
        public const string Customer_Read = "EXEC [dbo].[Customer_Read] @CustomerID";
        public const string Customer_Create = "EXEC [dbo].[Customer_Create] @CustomerID, @FirstName, @LastName, @DateOfBirth, @Address, @City, @State, @ZipCode";
        public const string Customer_Update = "EXEC [dbo].[Customer_Update] @CustomerID, @FirstName, @LastName, @DateOfBirth, @Address, @City, @State, @ZipCode";
        public const string Customer_Delete = "EXEC @ReturnCode = [dbo].[Customer_Delete] @CustomerID";
        public const string User_Create = "EXEC [dbo].[User_Create] @UserID, @UserRole, @FirstName, @LastName, @Username, @PasswordHash, @PasswordSalt";
        public const string Users_Read = "EXEC [dbo].[Users_Read]";
    }
}