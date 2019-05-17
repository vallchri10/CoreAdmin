CREATE TABLE [dbo].[Customers] (
    [CustomerID]  NVARCHAR (10) NOT NULL,
    [FirstName]   NVARCHAR (50) NULL,
    [LastName]    NVARCHAR (50) NULL,
    [DateOfBirth] DATETIME2 (7) NULL,
    [Address]     NVARCHAR (50) NULL,
    CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);

