CREATE PROCEDURE [dbo].[Customer_Create]
	@CustomerID NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATETIME2(7), 
	@Address NVARCHAR(50)
AS

SET NOCOUNT ON
BEGIN
		INSERT INTO dbo.Customers(CustomerID, FirstName, LastName, DateOfBirth, Address)
		VALUES(@CustomerID, @FirstName, @LastName, @DateOfBirth, @Address)
END