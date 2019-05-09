USE [CoreDatabase]
GO
/****** Object:  StoredProcedure [dbo].[Create]    Script Date: 5/5/2019 6:51:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Create]
	@CustomerID NVARCHAR(10),
	@FirstName NVARCHAR(50),
	@LastName NVARCHAR(50),
	@DateOfBirth DATETIME2(7), 
	@Address NVARCHAR(50),
	@ERROR int output
AS

SET NOCOUNT ON
BEGIN
	INSERT INTO dbo.Customers(CustomerID, FirstName, LastName, DateOfBirth, Address)
	VALUES(@CustomerID, @FirstName, @LastName,@DateOfBirth,@Address)
END

IF(@@ERROR <> 0)
	SET @ERROR = @@ERROR
ELSE
	SET @ERROR = 0

IF(@@ROWCOUNT > 0)
	RETURN 0
ELSE
	RETURN -1