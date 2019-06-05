CREATE PROCEDURE [dbo].[Users_Read]

AS

SET NOCOUNT ON
BEGIN
	SELECT 
		UserID,   
		UserRole, 
		FirstName,
		LastName, 
		Username, 
		PasswordHash,
		PasswordSalt

	FROM 
		[dbo].Users
END