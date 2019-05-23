CREATE PROCEDURE [dbo].[Customer_Update]
	@CustomerID NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATETIME2(7),
	@Address NVARCHAR(50)
AS

SET NOCOUNT ON
BEGIN
IF  EXISTS
(
	SELECT Customers.CustomerID
	FROM [dbo].Customers
	WHERE CustomerID = @CustomerID
)
	UPDATE Customers
	SET CustomerID = @CustomerID,
		FirstName = @FirstName,
		LastName = @LastName, 
		DateOfBirth  = @DateOfBirth,
		Address  = @Address
	WHERE CustomerID = @CustomerID
ELSE
	THROW 51000, 'Record not found.', 1;  
END