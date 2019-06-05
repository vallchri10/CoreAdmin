--CREATE PROCEDURE [dbo].[UPSERT]
-- @CustomerID NVARCHAR(10),
--	@FirstName NVARCHAR(50),
--	@LastName NVARCHAR(50),
--	@DateOfBirth DATETIME2(7),
--	@Address NVARCHAR(50),
--	@ERROR int output
--AS

--BEGIN

--MERGE INTO [dbo].[Customers] AS target
--	USING
--	(SELECT @CustomerID AS [CustomerID]) AS source
--	on
--	(target.[CustomerID] = source.[CustomerID])

--WHEN MATCHED THEN
--	UPDATE SET 
--	target.[CustomerID] = @CustomerID,

--WHEN NOT MATCHED THEN 
--		INSERT INTO dbo.Customers(CustomerID, FirstName, LastName, DateOfBirth, Address)
--		VALUES(@CustomerID, @FirstName, @LastName,@DateOfBirth,@Address); 
--END

--IF(@@ERROR <> 0)
--	SET @ERROR = @@ERROR
--ELSE
--	SET @ERROR = 0

--IF(@@ROWCOUNT > 0)
--	RETURN 0
--ELSE
--	RETURN -1
