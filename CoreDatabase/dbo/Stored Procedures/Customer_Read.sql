CREATE PROCEDURE [dbo].[Customer_Read]
	@CustomerID NVARCHAR(10)

AS

SET NOCOUNT ON
BEGIN
IF  EXISTS
(
	SELECT Customers.CustomerID
	FROM [dbo].Customers
	WHERE CustomerID = @CustomerID
)
	SELECT *
	FROM [dbo].Customers
	WHERE CustomerID = @CustomerID
ELSE
	THROW 51000, 'Record not found.', 1;  
	RETURN
END