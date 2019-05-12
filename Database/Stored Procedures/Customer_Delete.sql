CREATE PROCEDURE [dbo].[Customer_Delete]
	@CustomerID VARCHAR(10)
AS

SET NOCOUNT ON
BEGIN
IF  EXISTS
(
	SELECT *
	FROM [dbo].Customers
	WHERE CustomerID = @CustomerID
)
	SELECT *
	FROM [dbo].Customers
	WHERE CustomerID = @CustomerID

	DELETE FROM Customers
	WHERE  CustomerID = @CustomerID

IF(@@ROWCOUNT > 0)
	RETURN 1
ELSE
	THROW 51000, 'The record does not exist.', 1;  
END