USE [CoreDatabase]
GO
/****** Object:  StoredProcedure [dbo].[Update]    Script Date: 5/5/2019 6:52:34 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Update]
	@CustomerID NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATETIME2(7),
	@Address NVARCHAR(50),
	@ERROR int output
AS

SET NOCOUNT ON
BEGIN
	UPDATE Customers
	SET CustomerID = @CustomerID,
		FirstName = @FirstName,
		LastName = @LastName, 
		DateOfBirth  = @DateOfBirth,
		Address  = @Address
	WHERE CustomerID = @CustomerID
END

IF(@@ERROR <> 0)
	SET @ERROR = @@ERROR
ELSE
	SET @ERROR = 0

IF(@@ROWCOUNT > 0)
	RETURN 0
ELSE
	RETURN -1