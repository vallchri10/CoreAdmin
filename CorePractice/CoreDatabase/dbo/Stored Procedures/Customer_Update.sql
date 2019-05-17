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
	SELECT *
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

	IF(@@ROWCOUNT > 0)
	RETURN 1

ELSE
	THROW 51000, 'The record does not exist.', 1;  
END