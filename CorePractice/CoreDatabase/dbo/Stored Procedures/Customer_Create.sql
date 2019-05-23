CREATE PROCEDURE [dbo].[Customer_Create]
	@CustomerID NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATETIME2(7), 
	@Address NVARCHAR(50)
AS

SET NOCOUNT ON
BEGIN
	BEGIN TRY
		INSERT INTO dbo.Customers(CustomerID, FirstName, LastName, DateOfBirth, Address)
		VALUES(@CustomerID, @FirstName, @LastName, @DateOfBirth, @Address)
	END TRY

	BEGIN CATCH
		THROW 50001, 'Record already exists.', 1;  
		RETURN
	END CATCH
END