CREATE PROCEDURE [dbo].[Customers_Read]

AS

SET NOCOUNT ON
BEGIN
    SELECT *
    FROM [dbo].Customers
END