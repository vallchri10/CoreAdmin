CREATE PROCEDURE [dbo].[Read]
    @CustomerID VARCHAR(10),
    @ERROR int output
AS

SET NOCOUNT ON
BEGIN
    SELECT *
    FROM [dbo].Customers
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