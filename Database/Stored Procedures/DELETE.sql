USE [CoreDatabase]
GO
/****** Object:  StoredProcedure [dbo].[Delete]    Script Date: 5/5/2019 6:52:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Delete]
    @CustomerID VARCHAR(10),
    @ERROR int output
AS

SET NOCOUNT ON
BEGIN
    DELETE FROM Customers
    WHERE  CustomerID = @CustomerID
END

IF(@@ERROR <> 0)
    SET @ERROR = @@ERROR
ELSE
    SET @ERROR = 0

IF(@@ROWCOUNT > 0)
    RETURN 0
ELSE
    RETURN -1