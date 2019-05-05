CREATE PROCEDURE [dbo].[Create]
    @CustomerID VARCHAR(10),
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @ERROR int output
AS

SET NOCOUNT ON
BEGIN
    INSERT INTO dbo.Customers(CustomerID, FirstName,LastName)
    VALUES(@CustomerID, @FirstName, @LastName)
END

IF(@@ERROR <> 0)
    SET @ERROR = @@ERROR
ELSE
    SET @ERROR = 0

IF(@@ROWCOUNT > 0)
    RETURN 0
ELSE
    RETURN -1