CREATE PROCEDURE [dbo].[User_Create]
	@UserID NVARCHAR(10),
	@UserRole NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@Username NVARCHAR(50),
	@PasswordHash VARBINARY(MAX),
	@PasswordSalt VARBINARY(MAX)
AS

SET NOCOUNT ON
BEGIN
	BEGIN TRY
		INSERT INTO dbo.Users(UserID, UserRole, FirstName, LastName, Username, PasswordHash, PasswordSalt)
		VALUES(@UserID, @UserRole, @FirstName, @LastName, @Username, @PasswordHash, @PasswordSalt)
	END TRY

	BEGIN CATCH
		THROW 50001, 'Record already exists.', 1;  
		RETURN
	END CATCH
END