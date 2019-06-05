CREATE PROCEDURE [dbo].[Customer_Create]
	@CustomerID NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATE, 
	@Address NVARCHAR(50),
	@City NVARCHAR (50),
	@State NVARCHAR (50),
	@ZipCode NVARCHAR (15) 
AS

SET NOCOUNT ON
BEGIN
	BEGIN TRY
		INSERT INTO dbo.Customers(CustomerID, FirstName, LastName, DateOfBirth, Address, City, State, ZipCode)
		VALUES(@CustomerID, @FirstName, @LastName, @DateOfBirth, @Address, @City, @State, @ZipCode)
	END TRY

	BEGIN CATCH
		THROW 50001, 'Record already exists.', 1;  
		RETURN
	END CATCH
END