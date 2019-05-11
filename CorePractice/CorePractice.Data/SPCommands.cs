namespace CorePractice.Data
{
    public static class SPCommands
    {
        public const string Customers_Read = "EXEC [dbo].[Customers_Read]";
        public const string Customer_Read = "EXEC @ReturnCode = [dbo].[Customer_Read] @CustomerID";
        public const string Customer_Create = "EXEC [dbo].[Customer_Create] @CustomerID, @FirstName, @LastName, @DateOfBirth, @Address";
        public const string Customer_Update = "EXEC @ReturnCode = [dbo].[Customer_Update] @CustomerID, @FirstName, @LastName, @DateOfBirth, @Address";
    }
}