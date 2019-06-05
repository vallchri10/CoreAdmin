CREATE TABLE [dbo].[Customers] (
	[CustomerID]  NVARCHAR (10) NOT NULL,
	[FirstName]   NVARCHAR (50) NULL,
	[LastName]    NVARCHAR (50) NULL,
	[DateOfBirth] DATE          NULL,
	[Address]     NVARCHAR (50) NULL,
	[City]        NVARCHAR (50) NULL,
	[State]       NVARCHAR (50) NULL,
	[ZipCode]     NVARCHAR (15) NULL,
	CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
);